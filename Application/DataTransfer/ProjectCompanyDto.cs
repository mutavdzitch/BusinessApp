using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ProjectCompanyDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
