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
    public class EfGetStatusesCommand : BaseEfCommand, IGetStatusesCommand
    {
        public EfGetStatusesCommand(BusinessContext context) : base(context)
        {

        }
        public IEnumerable<StatusDto> Execute(StatusSearch request)
        {
            var query = Context.Statuses.AsQueryable();

            if(request.Value != null)
            {
                var keyword = request.Value.ToLower();
                query = query.Where(s => s.Value.ToLower().Contains(keyword));
            }
            if (request.ProjectId != null)
            {
                query = query.Where(v => v.StatusProjects.Any(p => p.Id == request.ProjectId));
            }
            if (request.TaskId != null)
            {
                query = query.Where(v => v.StatusTasks.Any(t => t.Id == request.TaskId));
            }
            return query
                .Select(s => new StatusDto
            {
                Id = s.Id,
                Value = s.Value,
                ProjectNames = s.StatusProjects.Select(p => p.Title),
                TaskNames = s.StatusTasks.Select(t => t.Title)
            });
        }
    }
}
