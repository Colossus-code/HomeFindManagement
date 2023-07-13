using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.DomainEntities
{
    public class Homes
    {

        public int Id { get; set; }

        public int HoodId { get; set; }

        public int Meters { get; set; }

        public Dictionary<string, decimal> Addons { get; set; }
    }
}
