using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class EmployeeSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? VocationId { get; set; }
        public int? CompanyId { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskProjectId { get; set; }
    }
}
