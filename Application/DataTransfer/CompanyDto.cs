using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int BankAccount { get; set; }
        public string WebSite { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
    }
}
