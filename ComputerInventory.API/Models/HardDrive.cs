using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Models
{
    public class HardDrive
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int ModelNumber { get; set; }
        public HDType Interface { get; set; }
        public int Capacity { get; set; }
        public UnitType UnitType { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
    }
    
}
