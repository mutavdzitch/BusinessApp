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
    public class EfGetTaskCommand : BaseEfCommand, IGetTaskCommand
    {
        public EfGetTaskCommand(BusinessContext context) : base(context)
        {

        }
        public TaskDto Execute(int request)
        {
            var query = Context.Tasks.AsQueryable();

            var task = query
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Where(s => s.Id == request).FirstOrDefault();

            if (task == null)
            {
                throw new EntityNotFoundException("Task");
            }

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                StatusId = task.Status.Id,
                StatusValue = task.Status.Value,
                ProjectId = task.Project.Id,
                ProjectName = task.Project.Title,
                EmployeeId = task.Employee.Id,
                EmployeeName = task.Employee.FirstName + ' ' + task.Employee.LastName
            };
        }
    }
}
