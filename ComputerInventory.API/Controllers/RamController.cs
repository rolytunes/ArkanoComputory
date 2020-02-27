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
    public class RamController : ControllerBase
    {
        private readonly IRamService _service;
        private readonly IMapper _mapper;

        public RamController(IRamService s, IMapper m)
        {
            _service = s;
            _mapper = m;
        }

        [HttpGet]
        public async Task<IEnumerable<RamResource>> ListAsync()
        {
            var rams = await _service.ListAsync();
            var resources = _mapper.Map<IEnumerable<Ram>, IEnumerable<RamResource>>(rams);
            return resources;
        }

        //get rams above 8 GB
        [HttpGet("above/{size}")]
        public async Task<IEnumerable<RamResource>> ListAsync(int size)
        {
            var rams = await _service.ListGreaterThanAsync(size);
            var resources = _mapper.Map<IEnumerable<Ram>, IEnumerable<RamResource>>(rams);
            return resources;
        }
    }
}