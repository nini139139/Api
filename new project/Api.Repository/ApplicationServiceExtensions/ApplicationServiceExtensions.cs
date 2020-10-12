using Api.Domain.Data;
using Api.Repository.Concrete.CompanyConcrete;
using Api.Repository.Concrete.MarketCompanyConcrete;
using Api.Repository.Concrete.MarketConcrete;
using Api.Repository.Concrete.UserConcrete;
using Api.Repository.Interfaces.CompanyInterface;
using Api.Repository.Interfaces.MarketCompanyInterface;
using Api.Repository.Interfaces.MarketInterface;
using Api.Repository.Interfaces.UserInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.ApplicationServiceExtensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IuserService, UserService>();
            services.AddScoped<IMarketRepo, MarketService>();
            services.AddScoped<IcompanyRepo, CompanyService>();
            services.AddScoped<IMarketCompany, MarketCompanyService>();
            services.AddDbContext<DataContxt>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Api.Domain"));
            });

            return services;
        }
    }
}
