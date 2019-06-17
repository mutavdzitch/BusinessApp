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
    public class EfAddProjectCommand : BaseEfCommand, IAddProjectCommand
    {
        public EfAddProjectCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(ProjectDto request)
        {
            Context.Projects.Add(new Domain.Project
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                StatusId = request.StatusId
            });
            Context.SaveChanges();
        }
    }
}
