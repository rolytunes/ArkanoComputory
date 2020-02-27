using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Models
{
    public class Ram
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public MemoryType Type { get; set; }
        public int Speed { get; set; }
        public int Capacity { get; set; }
        public int Pack { get; set; }

        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
    }
}
