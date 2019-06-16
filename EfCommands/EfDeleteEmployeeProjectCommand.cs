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
    public class EfDeleteEmployeeProjectCommand : BaseEfCommand, IDeleteEmployeeProjectCommand
    {
        public EfDeleteEmployeeProjectCommand(BusinessContext context) : base(context)
        {

        }

        public void Execute(DeleteEmployeeProjectDto request)
        {
            var employeeProject = Context.EmployeeProject
                 .Where(pc => pc.EmployeeId == request.EmployeeId && pc.ProjectId == request.ProjectId)
                 .FirstOrDefault();

            if (employeeProject == null)
            {
                throw new EntityNotFoundException("EmployeeProject");
            }

            Context.EmployeeProject.Remove(employeeProject);
            Context.SaveChanges();
        }
    }
}
