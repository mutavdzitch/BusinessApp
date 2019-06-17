using Application.Commands;
using Application.DataTransfer;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetVocationsCommand : BaseEfCommand, IGetVocationsCommand
    {
        public EfGetVocationsCommand(BusinessContext context) : base(context)
        {

        }
        public IEnumerable<VocationDto> Execute(VocationSearch request)
        {
            var query = Context.Vocations.AsQueryable();

            if(request.Name != null)
            {
                var keyword = request.Name.ToLower();
                query = query.Where(v => v.Name.ToLower().Contains(keyword));
            }
            if (request.EmployeeId != null)
            {
                query = query.Where(v => v.VocationEmployees.Any(e => e.Id == request.EmployeeId));
            }

            return query.Select(v => new VocationDto
            {
                Id = v.Id,
                Name = v.Name,
                EmployeeNames = v.VocationEmployees.Select(e => e.FirstName + ' ' + e.LastName)
        });
        }
    }
}
