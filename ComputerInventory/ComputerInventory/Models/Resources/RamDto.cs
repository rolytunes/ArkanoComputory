using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerInventory.Models.Resources
{
    public class RamDto : Ram
    {
        public override string ToString()
        {
            return "32GB (2 x 8 GB) - 3200 MHz - DDR4 ";
        }
    }
}
