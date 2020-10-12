using Api.Domain.Dto.CompanyDto;
using Api.Domain.Entity.Company;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces.CompanyInterface
{
   public interface IcompanyRepo
    {
        Task<Company> RegisterCompany(CompanyDto companyRegistration);
        Task<bool> CompanyExists(string marketName);
        Task<Company> GetCompanyById(int id);
        Task<Company> EditCompany(CompanyDto company);
        Task<List<Company>> GetCompanies();
    }
}
