using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class EmployeeProjectDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
