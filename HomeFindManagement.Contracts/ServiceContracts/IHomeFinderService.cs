using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFindManagement.Contracts.ServiceContracts
{
    public interface IHomeFinderService
    {
        Task<decimal> GetHomeFinderTotalPrice(int homeId);
    }
}
