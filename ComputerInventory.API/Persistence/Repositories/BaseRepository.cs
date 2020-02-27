using ComputerInventory.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ComputeryDbContext _context;
        public BaseRepository(ComputeryDbContext context)
        {
            _context = context;
        }
    }
}
