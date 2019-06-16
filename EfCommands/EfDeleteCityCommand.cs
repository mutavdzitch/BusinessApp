using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCityCommand : BaseEfCommand, IDeleteCityCommand
    {
        public EfDeleteCityCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if (city == null)
            {
                throw new EntityNotFoundException("City");
            }
            Context.Cities.Remove(city);
            Context.SaveChanges();
        }
    }
}
