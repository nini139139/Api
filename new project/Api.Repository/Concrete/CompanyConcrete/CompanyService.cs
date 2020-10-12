using Api.Domain.Data;
using Api.Domain.Dto.CompanyDto;
using Api.Domain.Entity.Company;
using Api.Repository.Interfaces.CompanyInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Concrete.CompanyConcrete
{
   public  class CompanyService : IcompanyRepo
    {
        private readonly DataContxt _context;

        public CompanyService(DataContxt context)
        {
           _context = context;
        }

        public async Task<Company> RegisterCompany(CompanyDto companyRegistration)
        {
            var company = new Company
            {
                CompanyName = companyRegistration.name.ToLower(),
            };
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var comapnyDb = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            return comapnyDb;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> EditCompany(CompanyDto company)
        {
            var companyDB = await _context.Companies.FirstOrDefaultAsync(x => x.Id == company.id);
            companyDB.CompanyName = company.name;
            await _context.SaveChangesAsync();
            return companyDB;
        }
        public async Task<bool> CompanyExists(string companyName)
        {
            return await _context.Companies.AnyAsync(x => x.CompanyName == companyName.ToLower());
        }

    }
}
