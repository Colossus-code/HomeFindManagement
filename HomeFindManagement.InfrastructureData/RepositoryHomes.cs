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
    public class RepositoryHomes : IRepositoryHomes
    {
        private readonly string _pathRoot;

        public RepositoryHomes(IConfiguration configuration)
        {
            _pathRoot = configuration.GetSection("ApiCalls:Homes").Value;
        }
        public async Task<List<Homes>> GetHomes()
        {
            List<HomesDto> homesDto = await RepositoryHelper.GetList<HomesDto>(_pathRoot);

            return TransformDtoToEntity(homesDto);
        }

        private List<Homes> TransformDtoToEntity(List<HomesDto> homesDto)
        {
            List<Homes> homesList = new List<Homes>();

            foreach (HomesDto homeDto in homesDto)
            {
                Homes home = new Homes
                {
                    Id = homeDto.Id,
                    HoodId = homeDto.HoodId,
                    Meters = homeDto.Meters,
                    Addons = homeDto.Addons
                };
             
                homesList.Add(home);
            }

            return homesList;
        }
    }
}
