using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerInventory.API.Models;
using ComputerInventory.API.Repositories;
using ComputerInventory.API.Resources;

namespace ComputerInventory.API.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _repository;

        public ComputerService(IComputerRepository r)
        {
            _repository = r;
        }
        public async Task<IEnumerable<Computer>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<IEnumerable<Computer>> ListAsyncLimit()
        {
            return await _repository.ListAsyncLimit();
        }
    }
}
