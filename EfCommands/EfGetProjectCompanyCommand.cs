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
    public class EfGetProjectCompanyCommand : BaseEfCommand, IGetProjectCompanyCommand
    {
        public EfGetProjectCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public ProjectCompanyDto Execute(int request)
        {
            var query = Context.ProjectCompany.AsQueryable();

            var projectCompany = query
                .Include(pc => pc.Company)
                .Include(pc => pc.Project)
                .Where(pc => pc.CompanyId == request)
                .Where(pc => pc.ProjectId == request)
                .FirstOrDefault();

            if (projectCompany == null)
            {
                throw new EntityNotFoundException("ProjectCompany");
            }

            return new ProjectCompanyDto
            {
                ProjectId = projectCompany.Project.Id,
                ProjectName = projectCompany.Project.Title,
                CompanyId = projectCompany.Company.Id,
                CompanyName = projectCompany.Company.Name
            };
        }
    }
}
