using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.InfrastructureData.DTOs
{
    public class HoodsDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        
        [JsonPropertyName("Nombre")]
        public string Names { get; set; }
        
        [JsonPropertyName("CosteM2")]
        public decimal PriceForMeter { get; set; }
    }
}
