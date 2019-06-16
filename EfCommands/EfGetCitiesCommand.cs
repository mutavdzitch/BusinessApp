using Application.Commands;
using Application.DataTransfer;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCitiesCommand : BaseEfCommand, IGetCitiesCommand
    {
        public EfGetCitiesCommand(BusinessContext context) : base(context)
        {

        }
        public IEnumerable<CityDto> Execute(CitySearch request)
        {
            var query = Context.Cities.AsQueryable();

            if(request.Name != null)
            {
                var keyword = request.Name.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(keyword));
            }
            if (request.PostalCode != null)
            {
                query = query.Where(c => c.PostalCode == request.PostalCode);
            }
            if (request.CompanyId != null)
            {
                query = query.Where(v => v.CityCompanies.Any(e => e.Id == request.CompanyId));
            }

            return query
                .Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name,
                PostalCode = c.PostalCode,
                CompanyNames = c.CityCompanies.Select(co => co.Name)
            });
        }
    }
}
