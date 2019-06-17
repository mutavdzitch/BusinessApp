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
    public class EfEditTaskCommand : BaseEfCommand, IEditTaskCommand
    {
        public EfEditTaskCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(TaskDto request)
        {
            var task = Context.Tasks.Find(request.Id);

            string ExceptionTmp = "Task";

            if (task == null)
            {
                throw new EntityNotFoundException(ExceptionTmp);
            }

            if (task.Title != request.Title)
            {
                if (Context.Projects.Any(p => p.Title == request.Title))
                {
                    throw new EntityAlreadyExistsException(ExceptionTmp);
                }

                task.Title = request.Title;
            }
            if (task.Description != request.Description)
            {
                task.Description = request.Description;
            }
            if (task.StartDate != request.StartDate)
            {
                task.StartDate = request.StartDate;
            }
            if (task.EndDate != request.EndDate)
            {
                task.EndDate = request.EndDate;
            }
            if (task.StatusId != request.StatusId)
            {
                task.StatusId = request.StatusId;
            }
            if (task.ProjectId != request.ProjectId)
            {
                task.ProjectId = request.ProjectId;
            }
            if (task.EmployeeId != request.EmployeeId)
            {
                task.EmployeeId = request.EmployeeId;
            }
            task.ModifiedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
