using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class VocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
    }
}
