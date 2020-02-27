using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Resources
{
    public class ComputerResource
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string OperatingSystem { get; set; }
        public string Graphics { get; set; }
    }
}
