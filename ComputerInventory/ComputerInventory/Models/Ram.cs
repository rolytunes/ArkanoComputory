using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerInventory.Models
{
    public class Ram
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("pack")]
        public int Pack { get; set; }

        [JsonProperty("computer")]
        public Computer Computer { get; set; }
    }
}
