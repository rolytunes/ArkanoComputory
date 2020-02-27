using ComputerInventory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Repositories
{
    public interface IRamRepository
    {
        Task<IEnumerable<Ram>> ListAsync();
        Task<IEnumerable<Ram>> ListGreaterThanAsync(int size);
    }
}
