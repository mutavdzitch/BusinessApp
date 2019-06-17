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
    public class EfAddEmployeeCommand : BaseEfCommand, IAddEmployeeCommand
    {
        public EfAddEmployeeCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(EmployeeDto request)
        {
            if(Context.Employees.Any(e => e.Username == request.Username))
            {
                throw new EntityAlreadyExistsException("Employee");
            }
            if (Context.Employees.Any(e => e.Email == request.Email))
            {
                throw new EntityAlreadyExistsException("Employee");
            }

            Context.Employees.Add(new Domain.Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                CompanyId = request.CompanyId,
                VocationId = request.VocationId
            });

            Context.SaveChanges();
        }
    }
}
