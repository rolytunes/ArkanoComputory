using ComputerInventory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Services
{
    public interface IRamService
    {
        Task<IEnumerable<Ram>> ListAsync();
        Task<IEnumerable<Ram>> ListGreaterThanAsync(int size);
    }
}
