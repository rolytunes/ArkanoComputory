using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Models
{
    public class Processor
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int ModelNumber { get; set; }

        public int ComputerId { get; set; }
        public Computer Computer { get; set; }

    }
}
