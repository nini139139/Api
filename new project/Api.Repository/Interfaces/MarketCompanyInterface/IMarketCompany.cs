using Api.Domain.Dto;
using Api.Domain.Entity.Market;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces.MarketCompanyInterface
{
    public  interface IMarketCompany
    {
        Task<MarketCompany> RegisterMarketCompanyConnection(MarketCompanyDto model);
        Task<bool> ExistMarketCompanyRelation(MarketCompanyDto model);
        Task<MarketCompany> EditMarketCompanyConnectio(MarketCompanyDto model);
        Task<MarketCompany> GetMarketCompanyByConnection(MarketCompanyDto model);
        Task<List<MarketCompanyDto>> GetMarketCompanies();
        
    }
}
