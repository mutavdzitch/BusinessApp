using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public string StatusValue { get; set; }
        public IEnumerable<string> CompanyNames { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
