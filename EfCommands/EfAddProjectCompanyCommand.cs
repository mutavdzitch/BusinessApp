using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfAddProjectCompanyCommand : BaseEfCommand, IAddProjectCompanyCommand
    {
        public EfAddProjectCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(ProjectCompanyDto request)
        {
            Context.ProjectCompany.Add(new Domain.ProjectCompany
            {
                ProjectId = request.ProjectId,
                CompanyId = request.CompanyId
            });
            Context.SaveChanges();
        }
    }
}
