using ComputerInventory.API.Models;
using ComputerInventory.API.Persistence.Contexts;
using ComputerInventory.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Repositories
{
    public class RamRepository : BaseRepository, IRamRepository
    {
        public RamRepository(ComputeryDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Ram>> ListAsync()
        {
            return await _context.Rams.Include(c => c.Computer).ToListAsync();
        }

        public async Task<IEnumerable<Ram>> ListGreaterThanAsync(int size)
        {
            return await _context.Rams.Where(r => r.Capacity * r.Pack >= size).Include(c => c.Computer).ToListAsync();
        }
    }
}
