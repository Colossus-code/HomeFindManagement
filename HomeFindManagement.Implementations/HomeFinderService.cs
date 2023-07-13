using HomeFindManagement.Contracts.DomainEntities;
using HomeFindManagement.Contracts.RepositoryContracts;
using HomeFindManagement.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.Implementations
{
    public class HomeFinderService : IHomeFinderService
    {
        private readonly IRepositoryAddons _repositoryAddons;

        private readonly IRepositoryCache _repositoryCache;
        
        private readonly IRepositoryHomes _repositoryHomes;

        private readonly IRepositoryHoods _repositoryHoods;

        public HomeFinderService(IRepositoryAddons repoAddons, IRepositoryCache repoCache, IRepositoryHomes repoHome, IRepositoryHoods repositoryHoods)
        {
            _repositoryAddons = repoAddons;
            _repositoryCache = repoCache;
            _repositoryHomes = repoHome;
            _repositoryHoods = repositoryHoods;
        
        }
        public async Task<decimal> GetHomeFinderTotalPrice(int homeId)
        {
            HousePrice housePriceCached =  _repositoryCache.GetCache<HousePrice>(homeId);

            if (housePriceCached != null) return housePriceCached.TotalCost;

            List<Homes> homesList = await _repositoryHomes.GetHomes();

            Homes home = FiltratedHome(homesList, homeId);
            
            if (!ValidateInformationRecived(home)) return 0;   

            List<Hoods> hoodsList = await _repositoryHoods.GetHoods();

            Addons addonsList = await _repositoryAddons.GetAddons();

            Hoods hood = FiltratedHood(hoodsList, homeId);

            HousePrice housePrice = new HousePrice
            {
                Id = homeId,
                TotalCost = TotalCost(home, hood, addonsList)
            };

            _repositoryCache.SetCache<HousePrice>(housePrice.Id, housePrice.TotalCost);

            return housePrice.TotalCost;
        }
        private Homes FiltratedHome(List<Homes> homes, int idHome)
        {
            return homes.FirstOrDefault(e => e.Id == idHome);
        }        
        private Hoods FiltratedHood(List<Hoods> hoods, int houseHoodId)
        {
            return hoods.FirstOrDefault(e => e.Id == houseHoodId);
        }

        private decimal TotalCost(Homes home, Hoods hood, Addons addons)
        {
            decimal totalCost = home.Meters * hood.PriceForMeter;

            foreach(string key in home.Addons.Keys)
            {
                decimal addonCostMetters = addons.HomeAddons[key].PriceM2;

                decimal addonCost = addons.HomeAddons[key].PriceCost; 

                if(addonCostMetters == 0)
                {
                    totalCost += addonCost;
                }
                else
                {
                    totalCost += addonCostMetters * home.Addons[key];
                }

            }

            return totalCost; 

        }

        private bool ValidateInformationRecived<T>(T genericObjet)
        {
            if (genericObjet != null) { return true; }

            return false;
        }
    }
}
