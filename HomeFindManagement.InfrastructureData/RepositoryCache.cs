using HomeFindManagement.Contracts.RepositoryContracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.InfrastructureData
{
    public class RepositoryCache : IRepositoryCache
    {
        private readonly IMemoryCache _memoryCache;
        
        public RepositoryCache(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;

        }

        public T GetCache<T>(int houseId)
        {
            var response = _memoryCache.Get(houseId);

            return (T)response; 
        }

        public void SetCache<T>(int houseId, decimal price) 
        {
            _memoryCache.Set(houseId, price);
        }
    }
}
