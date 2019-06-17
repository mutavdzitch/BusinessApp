using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public ICollection<Company> CityCompanies { get; set; }
    }
}
