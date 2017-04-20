using System;
using System.Collections.Generic;
using CrossOverAssignment.Business.Dtos;

namespace CrossOverAssignment.Business.Interfaces
{
    public interface IStockBusinessService
    {
        StockDto CreateStock(StockDto dto);

        int Delete(int id);

        int Delete(IList<int> ids);

        IList<StockDto> ReadStocksByUser(string userId, out int totalItem, int currentIndex = 0, int itemPerPage = 0);

        IList<StockDto> ReadNewPrice(IList<StockDto> stock);
    }
}
