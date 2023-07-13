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
    public class RepositoryHoods : IRepositoryHoods
    {
        private readonly string _pathRoot;

        public RepositoryHoods(IConfiguration configuration)
        {
            _pathRoot = configuration.GetSection("ApiCalls:Hoods").Value;
        }
        public async Task<List<Hoods>> GetHoods()
        {
            List<HoodsDto> hoodsDto = await RepositoryHelper.GetList<HoodsDto>(_pathRoot);

            return TransformDtoToEntity(hoodsDto);
        }

        private List<Hoods> TransformDtoToEntity(List<HoodsDto> hoodsDto)
        {
            
            List<Hoods> result = new List<Hoods>();

            foreach(var hood in hoodsDto)
            {
                result.Add(new Hoods
                {
                    Id = hood.Id,
                    Names = hood.Names,
                    PriceForMeter = hood.PriceForMeter,
                });
            }

            return result;
        }
    }
}
