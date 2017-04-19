using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.Business.Dtos;
using CrossOverAssignment.Business.Interfaces;

namespace CrossOverAssignment.Business.Implementations
{
    public class StockBusinessService : IStockBusinessService
    {
        public StockDto CreateStock(StockDto dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public IList<StockDto> ReadStocksByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
