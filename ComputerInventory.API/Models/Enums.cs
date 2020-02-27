using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Models
{
    public enum HDType
    {
        SATA,
        SSD
    }

    public enum UnitType
    {
        MB,
        GB,
        TB
    }

    public enum MemoryType
    {
        DDR3,
        DDR4,
    }
}
