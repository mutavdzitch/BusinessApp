using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class CompanySearch
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? BankAccount { get; set; }
        public string WebSite { get; set; }
        public int? CityId { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
