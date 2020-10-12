using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Domain.Data
{
    public class DataBaseContectFactory : IDesignTimeDbContextFactory<DataContxt>
    {

        public DataContxt CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var apsBuilder = new DbContextOptionsBuilder<DataContxt>();
            apsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new DataContxt(apsBuilder.Options); ;
        }
    }
}
