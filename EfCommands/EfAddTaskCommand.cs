using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfAddTaskCommand : BaseEfCommand, IAddTaskCommand
    {
        public EfAddTaskCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(TaskDto request)
        {
            Context.Tasks.Add(new Domain.Task
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId,
                EmployeeId = request.EmployeeId,
                ProjectId = request.ProjectId
            });
            Context.SaveChanges();
        }
    }
}
