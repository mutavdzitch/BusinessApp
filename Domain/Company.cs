using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int BankAccount { get; set; }
        public string WebSite { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Employee> CompanyEmployees { get; set; }
        public ICollection<ProjectCompany> CompanyProjects { get; set; }
    }
}
