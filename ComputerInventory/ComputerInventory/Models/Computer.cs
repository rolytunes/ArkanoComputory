using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerInventory.Models
{
    public class Computer
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }
        [JsonProperty("operatingSystem")]
        public string OperatingSystem { get; set; }
        [JsonProperty("graphics")]
        public string Graphics { get; set; }
    }
}
