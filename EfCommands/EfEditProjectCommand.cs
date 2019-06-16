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
    public class EfEditProjectCommand : BaseEfCommand, IEditProjectCommand
    {
        public EfEditProjectCommand(BusinessContext context) : base(context)
        {

        }

        public void Execute(ProjectDto request)
        {
            var project = Context.Projects.Find(request.Id);

            string ExceptionTmp = "Project";

            if (project == null)
            {
                throw new EntityNotFoundException(ExceptionTmp);
            }

            if (project.Title != request.Title)
            {
                if (Context.Projects.Any(p => p.Title == request.Title))
                {
                    throw new EntityAlreadyExistsException(ExceptionTmp);
                }

                project.Title = request.Title;
            }
            if (project.Description != request.Description)
            {
                project.Description = request.Description;
            }
            if (project.StartDate != request.StartDate)
            {
                project.StartDate = request.StartDate;
            }
            if (project.EndDate != request.EndDate)
            {
                project.EndDate = request.EndDate;
            }
            if (project.StatusId != request.StatusId)
            {
                project.StatusId = request.StatusId;
            }

            Context.SaveChanges();
        }
    }
}
