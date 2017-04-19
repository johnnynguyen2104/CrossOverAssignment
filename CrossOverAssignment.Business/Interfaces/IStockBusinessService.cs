using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.Business.Dtos;

namespace CrossOverAssignment.Business.Interfaces
{
    public interface IStockBusinessService
    {
        StockDto CreateStock(StockDto dto);

        int Delete(int id);

        int Delete(IList<int> ids);

        IList<StockDto> ReadStocksByUser(string userId);
    }
}
