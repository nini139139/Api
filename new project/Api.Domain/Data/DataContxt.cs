using Api.Domain.Entity.Company;
using Api.Domain.Entity.Market;
using Api.Domain.Entity.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Data
{
   public class DataContxt : DbContext
    {


        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataContxt>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOption = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DataContxt> opsBuilder { get; set; }
            public DbContextOptions<DataContxt> dbOption { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionBuild ops = new OptionBuild();

        public DataContxt(DbContextOptions<DataContxt> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketCompany> MarketCompanies { get;set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketCompany>()
                .HasKey(bc => new { bc.Company, bc.Market });
            modelBuilder.Entity<MarketCompany>()
                .HasOne(bc => bc.Companies)
                .WithMany(b => b.MarketCompanies)
                .HasForeignKey(bc => bc.Company);
            modelBuilder.Entity<MarketCompany>()
                .HasOne(bc => bc.Markets)
                .WithMany(c => c.MarketCompanies)
                .HasForeignKey(bc => bc.Market);
        }
    }
}


//add - migration Company
//update - database