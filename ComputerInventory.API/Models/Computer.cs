using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string OperatingSystem { get; set; }
        public string Graphics { get; set; }
        public Ram RamMemory { get; set; }
        public Processor Processor { get; set; }
        public HardDrive Storage { get; set; }     
    }
}
