using AutoMapper;
using ComputerInventory.API.Models;
using ComputerInventory.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Computer, ComputerResource>();
            CreateMap<Ram, RamResource>();
        }
    }
}
