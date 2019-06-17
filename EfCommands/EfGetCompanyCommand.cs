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
    public class EfGetCompanyCommand : BaseEfCommand, IGetCompanyCommand
    {
        public EfGetCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public CompanyDto Execute(int request)
        {
            var query = Context.Companies.AsQueryable();

            var company = query
                .Include(c => c.CompanyEmployees)
                .Include(c => c.CompanyProjects)
                    .ThenInclude(cp => cp.Project)
                .Include(c => c.City)
                .Where(s => s.Id == request).FirstOrDefault();

            if (company == null)
            {
                throw new EntityNotFoundException("Company");
            }

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                BankAccount = company.BankAccount,
                WebSite = company.WebSite,
                CityName = company.City.Name,
                ProjectNames = company.CompanyProjects.Select(cp => cp.Project.Title),
                EmployeeNames = company.CompanyEmployees.Select(ce => ce.FirstName + ' ' + ce.LastName)
            };
        }
    }
}
