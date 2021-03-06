﻿using ComputerInventory.API.Models;
using ComputerInventory.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Repositories
{
    public interface IComputerRepository
    {
        Task<IEnumerable<Computer>> ListAsync();
        Task<IEnumerable<Computer>> ListAsyncLimit();
    }
}
