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
    public class EfGetVocationCommand : BaseEfCommand, IGetVocationCommand
    {
        public EfGetVocationCommand(BusinessContext context) : base(context)
        {

        }
        public VocationDto Execute(int request)
        {
            var query = Context.Vocations.AsQueryable();

            var vocation = query.Include(v => v.VocationEmployees).
                Where(v => v.Id == request).FirstOrDefault();

            if (vocation == null)
            {
                throw new EntityNotFoundException("Vocation");
            }

            return new VocationDto
            {
                Id = vocation.Id,
                Name = vocation.Name,
                EmployeeNames = vocation.VocationEmployees.Select(e => e.FirstName + ' ' + e.LastName)
            };
        }
    }
}
