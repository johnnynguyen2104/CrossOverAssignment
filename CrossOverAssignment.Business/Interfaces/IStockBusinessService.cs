using System;
using System.Collections.Generic;
using CrossOverAssignment.Business.StockWebService;

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
