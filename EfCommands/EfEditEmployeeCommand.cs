using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EfCommands
{
    public class EfEditEmployeeCommand : BaseEfCommand, IEditEmployeeCommand
    {
        public EfEditEmployeeCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(EmployeeDto request)
        {
            var employee = Context.Employees.Find(request.Id);

            if(employee == null)
            {
                throw new EntityNotFoundException("Employee");
            }

            if(employee.FirstName != request.FirstName)
            {
                employee.FirstName = request.FirstName;
            }
            if (employee.LastName != request.LastName)
            {
                employee.LastName = request.LastName;
            }
            if (employee.Username != request.Username)
            {
                if (Context.Employees.Any(e => e.Username == request.Username))
                {
                    throw new EntityAlreadyExistsException("Employee");
                }

                employee.Username = request.Username;
            }
            if (employee.Email != request.Email)
            {
                if (Context.Employees.Any(e => e.Email == request.Email))
                {
                    throw new EntityAlreadyExistsException();
                }

                employee.Email = request.Email;
            }
            if (employee.Password != request.Password)
            {
                employee.Password = request.Password;
            }
            if (employee.PhoneNumber != request.PhoneNumber)
            {
                if (Context.Employees.Any(e => e.PhoneNumber == request.PhoneNumber))
                {
                    throw new EntityAlreadyExistsException();
                }

                employee.PhoneNumber = request.PhoneNumber;
            }
            if (employee.CompanyId != request.CompanyId)
            {
                employee.CompanyId = request.CompanyId;
            }
            if (employee.VocationId != request.VocationId)
            {
                employee.VocationId = request.VocationId;
            }
            employee.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
