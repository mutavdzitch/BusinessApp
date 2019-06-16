using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int StatusId { get; set; }
        public string StatusValue { get; set; }
    }
}
