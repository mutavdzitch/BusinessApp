using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ProjectSearch
    {
        public string Title { get; set; }
        public DateTime? StartDateOf { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateOf { get; set; }
        public DateTime? EndDateTo { get; set; }
        public int? StatusId { get; set; }
        public int? CompanyId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TaskEmployeeId { get; set; }

        public int PerPage { get; set; } = 100;
        public int PageNumber { get; set; } = 1;
    }
}
