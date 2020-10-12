using Api.Domain.Data;
using Api.Domain.Dto;
using Api.Domain.Entity.Market;
using Api.Repository.Interfaces.MarketCompanyInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Concrete.MarketCompanyConcrete
{
    public class MarketCompanyService : IMarketCompany
    {
        private readonly DataContxt _context;

        public MarketCompanyService(DataContxt context)
        {
            _context = context;
        }
        
        public async Task<MarketCompany> RegisterMarketCompanyConnection(MarketCompanyDto model)
        {


            var marketCompany = new MarketCompany();
            marketCompany = new MarketCompany
            {
                Company = model.CompanyId,
                Market = model.MarketId,
                Price = model.Price
            };
            _context.MarketCompanies.Add(marketCompany);

            await _context.SaveChangesAsync();

            return marketCompany;
        }


        public async Task<MarketCompany> EditMarketCompanyConnectio(MarketCompanyDto model)
        {
            var marketFromDb = await _context.MarketCompanies.FirstOrDefaultAsync(x => x.Company == model.CompanyId && x.Market == model.MarketId);
            marketFromDb.Company = model.CompanyId;
            marketFromDb.Market = model.MarketId;
            marketFromDb.Price = model.Price;
            await _context.SaveChangesAsync();
            return marketFromDb;
        }

        public async  Task<MarketCompany> GetMarketCompanyByConnection(MarketCompanyDto model)
        {
            var marketFromDb = await _context.MarketCompanies.FirstOrDefaultAsync(x => x.Company == model.CompanyId && x.Market == model.MarketId);
            return marketFromDb;
        }

        public async Task<bool> ExistMarketCompanyRelation(MarketCompanyDto model)
        {
            var marketFromDb = await _context.MarketCompanies.AnyAsync(x => x.Company == model.CompanyId && x.Market == model.MarketId);

            return marketFromDb;
        }

        public async Task<List<MarketCompanyDto>> GetMarketCompanies()
        {
            var marketCompanies = await _context.MarketCompanies
                .Include(c=>c.Companies)
                .Include(c=>c.Markets) 
                .ToListAsync();

            var result = marketCompanies.Select(c => new MarketCompanyDto
            {
                CompanyId = c.Company,
                CompanyName = c.Companies.CompanyName,
                MarketId = c.Market,
                MarketName = c.Markets.Name,
                Price = c.Price
            }).ToList();


            return result;
        }
    }
}
