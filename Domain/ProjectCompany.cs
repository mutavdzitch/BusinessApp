using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProjectCompany
    {
        public int ProjectId { get; set; }
        public int CompanyId { get; set; }
        public Project Project { get; set; }
        public Company Company { get; set; }
    }
}
