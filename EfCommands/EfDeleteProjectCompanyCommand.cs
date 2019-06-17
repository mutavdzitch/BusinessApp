using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfDeleteProjectCompanyCommand : BaseEfCommand, IDeleteProjectCompanyCommand
    {
        public EfDeleteProjectCompanyCommand(BusinessContext context) : base(context)
        {

        }

        public void Execute(DeleteProjectCompanyDto request)
        {
            var projectCompany = Context.ProjectCompany
                .Where(pc => pc.CompanyId == request.CompanyId && pc.ProjectId == request.ProjectId)
                .FirstOrDefault();

            if (projectCompany == null)
            {
                throw new EntityNotFoundException("ProjectCompany");
            }

            Context.ProjectCompany.Remove(projectCompany);
            Context.SaveChanges();
        }
    }
}
