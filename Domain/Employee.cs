using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public int VocationId { get; set; }
        public Company Company { get; set; }
        public Vocation Vocation { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<Task> EmployeeTasks { get; set; }
    }
}
