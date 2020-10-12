using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entity.Market
{
    public class MarketCompany
    {
        public int Company { get; set; }
        public Domain.Entity.Company.Company Companies { get; set; }
        public int Market { get; set; }
        public Domain.Entity.Market.Market Markets { get; set; }
        public int Price { get; set; }
    }
}
