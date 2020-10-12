using Api.Domain.Dto.MarketDto;
using Api.Domain.Entity.Market;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces.MarketInterface
{
    public interface IMarketRepo
    {
        Task<Market> RegisterMarket(MarketDto marketRegistration);
        Task<Market> EditMarket(MarketDto market);
        Task<Market> GetMarketById(int id);
        Task<List<Market>> GetMarkets();
        Task<bool> MarketExists(string marketName);
    }
}
