using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.InfrastructureData.DTOs
{
    public class PriceDto
    {
        [JsonPropertyName("precioM2")]
        public decimal PriceM2 { get; set; }
        
        [JsonPropertyName("precio")]
        public decimal Price {get; set; }

    }
}
