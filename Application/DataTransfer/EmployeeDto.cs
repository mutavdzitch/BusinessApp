using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int VocationId { get; set; }
        public string VocationName { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
