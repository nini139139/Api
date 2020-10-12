using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dto.MarketDto;
using Api.Domain.Entity.Market;
using Api.Repository.Interfaces.MarketInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.MarketController
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MarketController : Controller
    {
        private readonly IMarketRepo _marketService;

        public MarketController(IMarketRepo marketService)
        {
            _marketService = marketService;
        }

        [HttpPost("AddMarket")]
        public async Task<ActionResult<MarketDto>> Register(MarketDto registerMarket)
        {
            if (await _marketService.MarketExists(registerMarket.name)) return BadRequest("მსგავსი მარკეტი უკვე არსებობს");
            var user =await _marketService.RegisterMarket(registerMarket);
            return Ok("წარმატებით დაემატა");
        }
        [HttpPost("EditMarket")]
        public async Task<ActionResult<MarketDto>> EditMarket(MarketDto registerMarket)
        {
            var marketDb = await _marketService.GetMarketById(registerMarket.id);
            if(registerMarket.id== marketDb.Id && registerMarket.name!= marketDb.Name)
            {
                if (await _marketService.MarketExists(registerMarket.name)) return BadRequest("მსგავსი მარკეტი უკვე არსებობს");
            }
            var market = await _marketService.EditMarket(registerMarket);
            return Ok("წარმატებით განახლდა");
        }

        [HttpGet("GetMarkets")]
        public async Task<ActionResult<IEnumerable<Market>>> GetMarkets()
        {
            var result = await _marketService.GetMarkets();
            return result;
        }
    }
}
