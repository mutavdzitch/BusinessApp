using Application.Commands;
using Application.DataTransfer;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetProjectCompaniesCommand : BaseEfCommand, IGetProjectCompaniesCommand
    {
        public EfGetProjectCompaniesCommand(BusinessContext context) : base(context)
        {
        }
        public IEnumerable<ProjectCompanyDto> Execute(ProjectCompanySearch request)
        {
            var query = Context.ProjectCompany.AsQueryable();

            if (request.ProjectId != null)
            {
                query = query.Where(pc => pc.ProjectId == request.ProjectId);
            }
            if (request.CompanyId != null)
            {
                query = query.Where(pc => pc.CompanyId == request.CompanyId);
            }

            return query.Select(pc => new ProjectCompanyDto
            {
                ProjectId = pc.Project.Id,
                ProjectName = pc.Project.Title,
                CompanyId = pc.Company.Id,
                CompanyName = pc.Company.Name
            });
        }
    }
}
