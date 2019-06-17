using Application.Commands;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetEmployeesCommand : BaseEfCommand, IGetEmployeesCommand
    {
        public EfGetEmployeesCommand(BusinessContext context) : base(context)
        {
        }

        public IEnumerable<EmployeeDto> Execute(EmployeeSearch request)
        {
            var query = Context.Employees.AsQueryable();

            if (request.FirstName != null)
            {
                var keyword = request.FirstName.ToLower();
                query = query.Where(e => e.FirstName.ToLower().Contains(keyword));
            }
            if (request.LastName != null)
            {
                var keyword = request.LastName.ToLower();
                query = query.Where(e => e.LastName.ToLower().Contains(keyword));
            }
            if (request.Username != null)
            {
                var keyword = request.Username.ToLower();
                query = query.Where(e => e.Username.ToLower().Contains(keyword));
            }
            if (request.Email != null)
            {
                var keyword = request.Email.ToLower();
                query = query.Where(e => e.Email.ToLower().Contains(keyword));
            }

            if (request.ProjectId != null)
            {
                query = query.Where(e => e.EmployeeProjects.Any(ep => ep.ProjectId == request.ProjectId));
            }
            if (request.TaskProjectId != null)
            {
                query = query.Where(e => e.EmployeeTasks.Any(t => t.ProjectId == request.TaskProjectId));
            }

            if (request.VocationId != null)
            {
                query = query.Where(e => e.VocationId == request.VocationId);
            }
            if (request.CompanyId != null)
            {
                query = query.Where(e => e.CompanyId == request.CompanyId);
            }

            return query.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Username = e.Username,
                Email = e.Email,
                Password = e.Password,
                PhoneNumber = e.PhoneNumber,
                CompanyId = e.Company.Id,
                CompanyName = e.Company.Name,
                VocationName = e.Vocation.Name,
                VocationId = e.Vocation.Id,
                ProjectNames = e.EmployeeProjects.Select(ep => ep.Project.Title),
                TaskNames = e.EmployeeTasks.Select(t => t.Title)
            }) ;

        }
    }
}