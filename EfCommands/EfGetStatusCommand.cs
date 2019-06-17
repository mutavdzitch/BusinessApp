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
    public class EfGetStatusCommand : BaseEfCommand, IGetStatusCommand
    {
        public EfGetStatusCommand(BusinessContext context) : base(context)
        {

        }
        public StatusDto Execute(int request)
        {
            var query = Context.Statuses.AsQueryable();

            var status = query.Include(s => s.StatusProjects).Include(s => s.StatusTasks).
                Where(s => s.Id == request).FirstOrDefault();

            if (status == null)
            {
                throw new EntityNotFoundException("Status");
            }
            return new StatusDto
            {
                Id = status.Id,
                Value = status.Value,
                ProjectNames = status.StatusProjects.Select(p => p.Title),
                TaskNames = status.StatusTasks.Select(t => t.Title)
            };
        }
    }
}
