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
    public class EfGetEmployeeProjectsCommand : BaseEfCommand, IGetEmployeeProjectsCommand
    {
        public EfGetEmployeeProjectsCommand(BusinessContext context) : base(context)
        {
        }
        public IEnumerable<EmployeeProjectDto> Execute(EmployeeProjectSearch request)
        {
            var query = Context.EmployeeProject.AsQueryable();

            if (request.ProjectId != null)
            {
                query = query.Where(ep => ep.ProjectId == request.ProjectId);
            }
            if (request.EmployeeId != null)
            {
                query = query.Where(ep => ep.EmployeeId == request.EmployeeId);
            }

            return query.Select(ep => new EmployeeProjectDto
            {
                ProjectId = ep.Project.Id,
                ProjectName = ep.Project.Title,
                EmployeeId = ep.Employee.Id,
                EmployeeName = ep.Employee.FirstName + ' ' + ep.Employee.LastName
            });
        }
    }
}
