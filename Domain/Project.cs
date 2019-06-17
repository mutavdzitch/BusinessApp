using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Project :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }  
        public ICollection<ProjectCompany> ProjectCompanies { get; set; }
        public ICollection<EmployeeProject> ProjectEmployees { get; set; }
        public ICollection<Task> ProjectTasks { get; set; }
    }
}
