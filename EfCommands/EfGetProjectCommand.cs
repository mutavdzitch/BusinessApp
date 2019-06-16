using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetProjectCommand : BaseEfCommand, IGetProjectCommand
    {
        public EfGetProjectCommand(BusinessContext context) : base(context)
        {

        }
        public ProjectDto Execute(int request)
        {
            var query = Context.Projects.AsQueryable();

            var project = query
                .Include(p => p.ProjectCompanies)
                    .ThenInclude(pc => pc.Company)
                .Include(p => p.ProjectEmployees)
                    .ThenInclude(pe => pe.Employee)
                .Include(p => p.ProjectTasks)
                .Include(p => p.Status)
                .Where(p => p.Id == request).FirstOrDefault();

            if (project == null)
            {
                throw new EntityNotFoundException("Project");
            }
            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                StatusId = project.Status.Id,
                StatusValue = project.Status.Value,
                CompanyNames = project.ProjectCompanies.Select(pc => pc.Company.Name),
                EmployeeNames = project.ProjectEmployees.Select(pe => pe.Employee.FirstName + ' ' + pe.Employee.LastName),
                TaskNames = project.ProjectTasks.Select(t => t.Title)
            };
        }

    }
}
