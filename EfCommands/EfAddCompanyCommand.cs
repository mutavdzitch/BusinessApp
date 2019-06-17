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
    public class EfAddCompanyCommand : BaseEfCommand, IAddCompanyCommand
    {
        public EfAddCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(CompanyDto request)
        {
            if(Context.Companies.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistsException("Company");
            }

            if (Context.Companies.Any(c => c.BankAccount == request.BankAccount))
            {
                throw new EntityAlreadyExistsException("Company");
            }

            Context.Companies.Add(new Domain.Company
            {
                Name = request.Name,
                Address = request.Name,
                PhoneNumber = request.PhoneNumber,
                BankAccount = request.BankAccount,
                WebSite = request.WebSite,
                CityId = request.CityId
            });

            Context.SaveChanges();
        }
    }
}
