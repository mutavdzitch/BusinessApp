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
    public class EfEditCompanyCommand : BaseEfCommand, IEditCompanyCommand
    {
        public EfEditCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(CompanyDto request)
        {
            var company = Context.Companies.Find(request.Id);
            if(company == null)
            {
                throw new EntityNotFoundException("Company");
            }

            if(company.Name != request.Name)
            {
                if (Context.Companies.Any(c => c.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("Company");
                }
                company.Name = request.Name;
            }
            if (company.Address != request.Address)
            {
                company.Address = request.Address;
            }
            if (company.PhoneNumber != request.PhoneNumber)
            {
                company.PhoneNumber = request.PhoneNumber;
            }
            if (company.BankAccount != request.BankAccount)
            {
                if (Context.Companies.Any(c => c.BankAccount == request.BankAccount))
                {
                    throw new EntityAlreadyExistsException("Company");
                }
                company.BankAccount = request.BankAccount;
            }
            if (company.WebSite != request.WebSite)
            {
                company.WebSite = request.WebSite;
            }
            if (company.CityId != request.CityId)
            {
                company.CityId = request.CityId;
            }

            Context.SaveChanges();
        }
    }
}
