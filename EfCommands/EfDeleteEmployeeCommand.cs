using Application.Commands;
using EfDataAccess;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteEmployeeCommand : BaseEfCommand, IDeleteEmployeeCommand
    {
        public EfDeleteEmployeeCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var employee = Context.Employees.Find(request);

            if(employee == null)
            {
                throw new EntityNotFoundException("Employee");
            }

            Context.Employees.Remove(employee);
            Context.SaveChanges();
        }
    }
}
