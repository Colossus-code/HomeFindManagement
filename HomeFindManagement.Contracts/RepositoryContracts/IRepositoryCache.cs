using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.RepositoryContracts
{
    public interface IRepositoryCache
    {

        T GetCache<T>(int houseId);

        void SetCache<T>(int houseId, decimal price);
    }
}
