using HomeFindManagement.Contracts.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.RepositoryContracts
{
    public interface IRepositoryHoods
    {
        Task<List<Hoods>> GetHoods();
    }
}
