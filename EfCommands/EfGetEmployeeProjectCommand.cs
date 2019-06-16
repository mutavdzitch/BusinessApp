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
    public class EfGetEmployeeProjectCommand : BaseEfCommand, IGetEmployeeProjectCommand
    {
        public EfGetEmployeeProjectCommand(BusinessContext context) : base(context)
        {

        }
        public EmployeeProjectDto Execute(int request)
        {
            var query = Context.EmployeeProject.AsQueryable();

            var employeeProject = query
                .Include(ep => ep.Employee)
                .Include(ep => ep.Project)
                .Where(ep => ep.EmployeeId == request)
                .Where(ep => ep.ProjectId == request)
                .FirstOrDefault();

            if (employeeProject == null)
            {
                throw new EntityNotFoundException("EmployeeProject");
            }

            return new EmployeeProjectDto
            {
                ProjectId = employeeProject.Project.Id,
                ProjectName = employeeProject.Project.Title,
                EmployeeId = employeeProject.Employee.Id,
                EmployeeName = employeeProject.Employee.FirstName + ' ' + employeeProject.Employee.LastName
            };
        }
    }
}
