using Api.Domain.Entity.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entity.Company
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public ICollection<MarketCompany> MarketCompanies { get; set; }
    }
}
