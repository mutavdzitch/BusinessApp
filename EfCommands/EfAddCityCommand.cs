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
    public class EfAddCityCommand : BaseEfCommand, IAddCityCommand
    {
        public EfAddCityCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(CityDto request)
        {
            if (Context.Cities.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistsException("City");
            }
            if (Context.Cities.Any(c => c.PostalCode == request.PostalCode))
            {
                throw new EntityAlreadyExistsException("City");
            }

            Context.Cities.Add(new Domain.City
            {
                Name = request.Name,
                PostalCode = request.PostalCode
            });

            Context.SaveChanges();
        }
    }
}
