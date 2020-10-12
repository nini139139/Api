using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Entity.Market;
using Api.Repository.Interfaces.MarketCompanyInterface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.MarketCompanyController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketCompanyController : Controller
    {
        private readonly IMarketCompany _marketCompanyService;

        public MarketCompanyController(IMarketCompany marketCompanyService)
        {
            _marketCompanyService = marketCompanyService;
        }
        [HttpPost("RegisterMarketCompanyConnection")]
        public async Task<ActionResult<MarketCompany>> RegisterMarketCompanyConnection(MarketCompanyDto registermarketCompany)
        {
            if (await _marketCompanyService.ExistMarketCompanyRelation(registermarketCompany)) return BadRequest("მსგავსი კავშირი უკვე არსებობს");
             await _marketCompanyService.RegisterMarketCompanyConnection(registermarketCompany);
            return Ok("წარმატებით დაემატა");
        }

        [HttpPost("EditMarketCompanyConnection")]
        public async Task<ActionResult<MarketCompany>> EditMarketCompanyConnectio(MarketCompanyDto registermarketCompany)
        {
            var exist = await _marketCompanyService.ExistMarketCompanyRelation(registermarketCompany);
            var marketCompanyDb = await _marketCompanyService.GetMarketCompanyByConnection(registermarketCompany);
            if (marketCompanyDb != null)
            {
                if (exist && registermarketCompany.Price != marketCompanyDb.Price)
                {
                    await _marketCompanyService.EditMarketCompanyConnectio(registermarketCompany);
                }
                else
                {
                    return BadRequest("მსგავსი კავშირი უკვე არსებობს");
                }
            }

    
            var company = await _marketCompanyService.EditMarketCompanyConnectio(registermarketCompany);
            return Ok("წარმატებით განახლდა");
        }

        [HttpGet("GetMarketCompanies")]
        public async Task<ActionResult<IEnumerable<MarketCompanyDto>>> GetMarketCompanies()
        {
            var marketCompanies = await _marketCompanyService.GetMarketCompanies();

            return marketCompanies;
        }
    }
}
