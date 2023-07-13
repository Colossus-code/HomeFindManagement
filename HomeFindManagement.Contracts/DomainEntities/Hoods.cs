using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.DomainEntities
{
    public class Hoods
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public decimal PriceForMeter { get; set; }
    }
}
