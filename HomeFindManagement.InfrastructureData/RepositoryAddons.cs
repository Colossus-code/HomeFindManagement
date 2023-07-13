using HomeFindManagement.Contracts.DomainEntities;
using HomeFindManagement.Contracts.RepositoryContracts;
using HomeFindManagement.InfrastructureData.DTOs;
using HomeFindManagement.InfrastructureData.RepositoryHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.InfrastructureData
{
    public class RepositoryAddons : IRepositoryAddons
    {
        private readonly string _pathRoot;

        public RepositoryAddons(IConfiguration configuration)
        {
            _pathRoot = configuration.GetSection("ApiCalls:Addons").Value;
        }
        public async Task<Addons> GetAddons()
        {
            AddonsDto addonsDto = new AddonsDto
            {
                Addons = await RepositoryHelper.GetObject<Dictionary<string, PriceDto>>(_pathRoot, null)
            };
            
            if(addonsDto.Addons == null) return null;

            return TransformDtoToEntity(addonsDto);
        }
        private Addons TransformDtoToEntity(AddonsDto addonsDto)
        {
            Addons addons = new Addons();

            addons.HomeAddons = new Dictionary<string, Price>();

            foreach(string key in addonsDto.Addons.Keys)
            {
                decimal priceM2 = addonsDto.Addons[key].PriceM2;
                
                decimal priceTotal = addonsDto.Addons[key].Price;

                Price price = new Price
                {
                    PriceM2 = priceM2,
                    PriceCost = priceTotal
                };

                addons.HomeAddons.Add(key, price);
            }

            return addons;
        }
    }
}
