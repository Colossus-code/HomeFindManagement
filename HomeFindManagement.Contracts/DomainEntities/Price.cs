using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.DomainEntities
{
    public class Price
    {

        public decimal PriceM2 { get; set; }

        public decimal PriceCost { get; set; }
    }
}
