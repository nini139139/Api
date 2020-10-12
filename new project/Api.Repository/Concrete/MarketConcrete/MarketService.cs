using Api.Domain.Data;
using Api.Domain.Dto.MarketDto;
using Api.Domain.Entity.Market;
using Api.Repository.Interfaces.MarketInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Concrete.MarketConcrete
{
   public  class MarketService: IMarketRepo
    {
        private readonly DataContxt _context;

        public MarketService(DataContxt context)
        {
            _context = context;
        }

        public async Task<Market> RegisterMarket(MarketDto marketRegistration)
        {
            var marketFromDb =await _context.Markets.FirstOrDefaultAsync(x => x.Name == marketRegistration.name);

            var market = new Market();
                market = new Market
                {
                    Name = marketRegistration.name.ToLower(),
                };
                _context.Markets.Add(market);
 
            await _context.SaveChangesAsync();

            return market;
        }


        public async Task<Market> EditMarket(MarketDto market)
        {
            var marketDB = await _context.Markets.FirstOrDefaultAsync(x => x.Id == market.id);
            marketDB.Name = market.name;
            await _context.SaveChangesAsync();
            return marketDB;
        }
        public async Task<Market> GetMarketById(int id)
        {
            var marketDB = await _context.Markets.FirstOrDefaultAsync(x => x.Id == id);
            return marketDB;
        }
        public async Task<bool> MarketExists(string marketName)
        {
            return await _context.Markets.AnyAsync(x => x.Name == marketName.ToLower());
        }

        public async Task<List<Market>> GetMarkets()
        {
            var markets = await _context.Markets.ToListAsync();
            return markets;
        }
    }
}
