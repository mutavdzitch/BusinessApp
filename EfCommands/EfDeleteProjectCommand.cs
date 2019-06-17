using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteProjectCommand : BaseEfCommand, IDeleteProjectCommand
    {
        public EfDeleteProjectCommand (BusinessContext context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var project = Context.Projects.Find(request);
            if(project == null)
            {
                throw new EntityNotFoundException("Project");
            }
            Context.Projects.Remove(project);
            Context.SaveChanges();
        }
    }
}
