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
    public class EfGetCompaniesCommand : BaseEfCommand, IGetCompaniesCommand
    {
        public EfGetCompaniesCommand(BusinessContext context) : base(context)
        {

        }
        public IEnumerable<CompanyDto> Execute(CompanySearch request)
        {
            var query = Context.Companies.AsQueryable();

            if(request.Name != null)
            {
                var keyword = request.Name.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(keyword));
            }
            if (request.Address != null)
            {
                var keyword = request.Address.ToLower();
                query = query.Where(c => c.Address.ToLower().Contains(keyword));
            }
            if (request.PhoneNumber != null)
            {
                var keyword = request.PhoneNumber;
                query = query.Where(c => c.PhoneNumber.Contains(keyword));
            }
            if (request.BankAccount != null)
            {
                query = query.Where(c => c.BankAccount == request.BankAccount);
            }
            if (request.WebSite != null)
            {
                var keyword = request.WebSite.ToLower();
                query = query.Where(c => c.WebSite.ToLower().Contains(keyword));
            }
            if (request.CityId != null)
            {
                query = query.Where(c => c.CityId == request.CityId);
            }
            if (request.ProjectId != null)
            {
                query = query.Where(c => c.CompanyProjects.Any(cp => cp.ProjectId == request.ProjectId));
            }
            if (request.EmployeeId != null)
            {
                query = query.Where(c => c.CompanyEmployees.Any(cp => cp.Id == request.EmployeeId));
            }

            return query.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                BankAccount = c.BankAccount,
                WebSite = c.WebSite,
                CityId = c.City.Id,
                CityName = c.City.Name,
                ProjectNames = c.CompanyProjects.Select(cp => cp.Project.Title),
                EmployeeNames = c.CompanyEmployees.Select(ce => ce.FirstName + ' ' + ce.LastName)
            });
        }
    }
}
