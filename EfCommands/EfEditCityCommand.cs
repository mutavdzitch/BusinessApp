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
    public class EfEditCityCommand : BaseEfCommand, IEditCityCommand
    {
        public EfEditCityCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(CityDto request)
        {
            var city = Context.Cities.Find(request.Id);
            if (city == null)
            {
                throw new EntityNotFoundException("City");
            }
            if (city.Name != request.Name)
            {
                if (Context.Cities.Any(c => c.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("City");
                }
                city.Name = request.Name;
            }
            if (city.PostalCode != request.PostalCode)
            {
                if (Context.Cities.Any(c => c.PostalCode == request.PostalCode))
                {
                    throw new EntityAlreadyExistsException("City");
                }
                city.PostalCode = request.PostalCode;
            }
            city.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
