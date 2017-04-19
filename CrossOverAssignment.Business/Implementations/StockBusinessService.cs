using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.Business.Dtos;
using CrossOverAssignment.Business.Interfaces;
using CrossOverAssignment.Business.StockWebService;
using CrossOverAssignment.DAL.DomainModels;
using CrossOverAssignment.DAL.Implementations;
using CrossOverAssignment.DAL.Interfaces;

namespace CrossOverAssignment.Business.Implementations
{
    public class StockBusinessService : IStockBusinessService
    {
        private readonly StockExchangeWebService stockExchangeWebService;

        private readonly IBaseRepository<int, Stock> stockRepository;

        public StockBusinessService(IBaseRepository<int, Stock> baseRepository)
        {
            stockRepository = baseRepository;
        }

        public StockBusinessService()
        {
            stockExchangeWebService = new StockExchangeWebService()
            {
                UserAuthValue = new UserAuth()
                {
                    UserName = "",
                    Password = ""
                }
            };

            stockRepository = new Repository<int, Stock>();
        }

        public StockDto CreateStock(StockDto dto)
        {
            Stock stock = new Stock() { StockCode = dto.StockCode, UserId = dto.UserId };

            var result = stockRepository.Create(stock);

            return stockRepository.CommitChanges() > 0
                ? new StockDto()
                {
                    UserId = result.UserId,
                    Id = result.Id,
                    StockCode = result.StockCode,
                    CreateDateTime = result.CreateDateTime,
                    UpdateDateTime = result.UpdateDateTime
                }
                : null;
        }

        public int Delete(int id)
        {
            stockRepository.Delete(a => a.Id == id);

            return stockRepository.CommitChanges();
        }

        public int Delete(IList<int> ids)
        {
            stockRepository.Delete(a => ids.Contains(a.Id));

            return stockRepository.CommitChanges();
        }

        public IList<StockDto> ReadStocksByUser(string userId)
        {
            var result = stockRepository.Read(a => a.UserId == userId)
                                        .Select(a => new StockDto()
                                        {
                                            UserId = a.UserId,
                                            Id = a.Id,
                                            StockCode = a.StockCode,
                                            CreateDateTime = a.CreateDateTime,
                                            UpdateDateTime = a.UpdateDateTime
                                        }).ToList();

            return result;
        }
    }
}
