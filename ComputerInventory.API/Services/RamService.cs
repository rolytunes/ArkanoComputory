using ComputerInventory.API.Models;
using ComputerInventory.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Services
{
    public class RamService : IRamService
    {
        private readonly IRamRepository _repository;
        public RamService(IRamRepository r)
        {
            _repository = r;
        }

        public async Task<IEnumerable<Ram>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<Ram>> ListGreaterThanAsync(int size)
        {
            return await _repository.ListGreaterThanAsync(size);
        }
    }
}
