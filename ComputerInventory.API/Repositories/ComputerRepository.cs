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
    public class ComputerRepository : BaseRepository, IComputerRepository
    {
        public ComputerRepository(ComputeryDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Computer>> ListAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<IEnumerable<Computer>> ListAsyncLimit()
        {
            return await _context.Computers.Take(3).ToListAsync();
        }
    }
}
