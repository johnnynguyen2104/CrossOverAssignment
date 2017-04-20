using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.Business.Dtos;
using CrossOverAssignment.Business.StockWebService;

namespace CrossOverAssignment.Business.Helpers
{
    public static class Mapping
    {
        public static IList<StockDto> MapStockWebServiceToDto(this StockWebDtos[] source)
        {
            return source.Select(a => new StockDto()
            {
                UserId = a.UserId,
                Id = a.Id,
                StockCode = a.StockCode,
                CreateDateTime = a.CreateDateTime,
                UpdateDateTime = a.UpdateDateTime,
                StockPrice = a.StockPrice
            }).ToList();
        }

        public static StockWebDtos[] MapStockDtoToStockWebService(this IList<StockDto> source)
        {
            return source.Select(a => new StockWebDtos()
            {
                UserId = a.UserId,
                Id = a.Id,
                StockCode = a.StockCode,
                CreateDateTime = a.CreateDateTime,
                UpdateDateTime = a.UpdateDateTime,
                StockPrice = a.StockPrice
            }).ToArray();
        }
    }
}
