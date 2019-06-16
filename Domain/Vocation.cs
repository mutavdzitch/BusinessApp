using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Vocation : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> VocationEmployees { get; set; }
    }
}
