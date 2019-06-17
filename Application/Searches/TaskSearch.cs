using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class TaskSearch
    {
        public string Title { get; set; }
        public DateTime? StartDateOf { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateOf { get; set; }
        public DateTime? EndDateTo { get; set; }
        public int? StatusId { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
