using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteTaskCommand : BaseEfCommand, IDeleteTaskCommand
    {
        public EfDeleteTaskCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var task = Context.Tasks.Find(request);

            if (task == null)
            {
                throw new EntityNotFoundException("Task");
            }

            Context.Tasks.Remove(task);
            Context.SaveChanges();
        }
    }
}
