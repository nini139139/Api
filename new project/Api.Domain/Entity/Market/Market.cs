using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entity.Market
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MarketCompany> MarketCompanies { get; set; }
        
    }
}
