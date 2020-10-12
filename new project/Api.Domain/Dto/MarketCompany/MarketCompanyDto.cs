using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dto
{
  public  class MarketCompanyDto
    {
        public int CompanyId { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public string CompanyName { get; set; }
        public int Price { get; set; }
    }
}
