using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.InfrastructureData.DTOs
{
    public class HomesDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IdBarrio")]
        public int HoodId { get; set; }

        [JsonPropertyName("M2")]
        public int Meters { get; set; }

        [JsonPropertyName("Añadidos")]
        public Dictionary<string, decimal> Addons { get; set; }
    }
}
