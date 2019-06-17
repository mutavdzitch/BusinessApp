using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfAddEmployeeProjectCommand : BaseEfCommand, IAddEmployeeProjectCommand
    {
        public EfAddEmployeeProjectCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(EmployeeProjectDto request)
        {
            Context.EmployeeProject.Add(new Domain.EmployeeProject
            {
                EmployeeId = request.EmployeeId,
                ProjectId = request.ProjectId
            });
            Context.SaveChanges();
        }
    }
}
