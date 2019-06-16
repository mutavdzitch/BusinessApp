using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCityCommand : BaseEfCommand, IGetCityCommand
    {
        public EfGetCityCommand(BusinessContext context) : base(context)
        {

        }
        public CityDto Execute(int request)
        {
            var query = Context.Cities.AsQueryable();

            var city = query.Include(c => c.CityCompanies).
                Where(c => c.Id == request).FirstOrDefault();

            if (city == null)
            {
                throw new EntityNotFoundException("City");
            }

            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                PostalCode = city.PostalCode,
                CompanyNames = city.CityCompanies.Select(co => co.Name)
            };
        }
    }
}
