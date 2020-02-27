using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComputerInventory.API.Models;
using ComputerInventory.API.Resources;
using ComputerInventory.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _service;
        private readonly IMapper _mapper;

        public ComputerController(IComputerService s, IMapper m)
        {
            _service = s;
            _mapper = m;
        }

        [HttpGet]
        public async Task<IEnumerable<ComputerResource>> GetComputersAsync()
        {
            var computers = await _service.ListAsync();
            var resources = _mapper.Map<IEnumerable<Computer>, IEnumerable<ComputerResource>>(computers);
            return resources;
        }

        [HttpGet("limit")]
        public async Task<IEnumerable<ComputerResource>> GetComputersAsyncLimit()
        {
            var computers = await _service.ListAsyncLimit();
            var resources = _mapper.Map<IEnumerable<Computer>, IEnumerable<ComputerResource>>(computers);
            return resources;
        }
    }
}