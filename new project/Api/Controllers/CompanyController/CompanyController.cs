using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dto.CompanyDto;
using Api.Domain.Entity.Company;
using Api.Repository.Interfaces.CompanyInterface;
using Api.Repository.Interfaces.MarketInterface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CompanyController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IcompanyRepo _CompanyService;

        public CompanyController (IcompanyRepo CompanyService)
        {
            _CompanyService = CompanyService;
        }
        [HttpPost("AddCompany")]
        public async Task<ActionResult<CompanyDto>> Register(CompanyDto registerCompany)
        {
            if (await _CompanyService.CompanyExists(registerCompany.name)) return BadRequest("მსგავსი კომპანია უკვე არსებობს");
            var user =await _CompanyService.RegisterCompany(registerCompany);
            return Ok("წარმატებით დაემატა");
        }

        [HttpPost("EditCompany")]
        public async Task<ActionResult<CompanyDto>> EditCompany(CompanyDto registerCompany)
        {
            var companyDb = await _CompanyService.GetCompanyById(registerCompany.id);
            if (registerCompany.id == companyDb.Id && registerCompany.name != companyDb.CompanyName)
            {
                if (await _CompanyService.CompanyExists(registerCompany.name)) return BadRequest("მსგავსი კომპანია უკვე არსებობს");
            }

            var company = await _CompanyService.EditCompany(registerCompany);
            return Ok("წარმატებით განახლდა");
        }

        [HttpGet("GetCompanies")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _CompanyService.GetCompanies(); ;
        }
    }
}
