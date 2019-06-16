using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Task : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
