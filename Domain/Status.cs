using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Status : BaseEntity
    {
        public static int DefaultStatusId => 1;
        public string Value { get; set; }
        public ICollection<Project> StatusProjects { get; set; }
        public ICollection<Task> StatusTasks { get; set; }
    }
}
