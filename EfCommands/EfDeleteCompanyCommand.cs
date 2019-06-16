using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCompanyCommand : BaseEfCommand, IDeleteCompanyCommand
    {
        public EfDeleteCompanyCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var company = Context.Companies.Find(request);

            if(company == null)
            {
                throw new EntityNotFoundException("Company");
            }

            Context.Companies.Remove(company);
            Context.SaveChanges();
        }
    }
}
