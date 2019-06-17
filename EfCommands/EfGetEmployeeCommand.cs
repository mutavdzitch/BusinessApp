using Application.Commands;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands
{
    public class EfGetEmployeeCommand : BaseEfCommand, IGetEmployeeCommand
    {
        public EfGetEmployeeCommand(BusinessContext context) : base(context)
        {
        }
        public EmployeeDto Execute(int request)
        {
            var query = Context.Employees.AsQueryable();

            var employee = query
                .Include(e => e.Company)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(cp => cp.Project)
                .Include(e => e.EmployeeTasks)
                .Include(e => e.Vocation)
                .Where(s => s.Id == request).FirstOrDefault();

            if (employee == null)
            {
                throw new EntityNotFoundException("Employee");
            }

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.Username,
                Email = employee.Email,
                Password = employee.Password,
                PhoneNumber = employee.PhoneNumber,
                CompanyId = employee.Company.Id,
                CompanyName = employee.Company.Name,
                VocationId = employee.Vocation.Id,
                VocationName = employee.Vocation.Name,
                ProjectNames = employee.EmployeeProjects.Select(ep => ep.Project.Title),
                TaskNames = employee.EmployeeTasks.Select(t => t.Title)
            };
        }
    }
}
