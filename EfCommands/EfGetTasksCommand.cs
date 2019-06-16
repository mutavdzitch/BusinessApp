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
    public class EfGetTasksCommand : BaseEfCommand, IGetTasksCommand
    {
        public EfGetTasksCommand(BusinessContext context) : base(context)
        {
        }
        public IEnumerable<TaskDto> Execute(TaskSearch request)
        {
            var query = Context.Tasks.AsQueryable();

            if (request.Title != null)
            {
                var keyword = request.Title.ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(keyword));
            }
            if (request.StartDateOf != null)
            {
                query = query.Where(t => t.StartDate >= request.StartDateOf);
            }
            if (request.StartDateTo != null)
            {
                query = query.Where(t => t.StartDate <= request.StartDateTo);
            }
            if (request.EndDateOf != null)
            {
                query = query.Where(t => t.EndDate >= request.EndDateOf);
            }
            if (request.EndDateTo != null)
            {
                query = query.Where(t => t.EndDate <= request.EndDateTo);
            }

            if (request.StatusId != null)
            {
                query = query.Where(t => t.StatusId == request.StatusId);
            }
            if (request.ProjectId != null)
            {
                query = query.Where(t => t.ProjectId == request.ProjectId);
            }
            if (request.EmployeeId != null)
            {
                query = query.Where(t => t.EmployeeId == request.EmployeeId);
            }

            return query.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                StatusId = t.Status.Id,
                StatusValue = t.Status.Value,
                ProjectId = t.Project.Id,
                ProjectName = t.Project.Title,
                EmployeeId = t.Employee.Id,
                EmployeeName = t.Employee.FirstName + ' ' + t.Employee.LastName
            });
        }
    }
}
