using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteStatusCommand : BaseEfCommand, IDeleteStatusCommand
    {
        public EfDeleteStatusCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var status = Context.Statuses.Find(request);

            if (status == null)
            {
                throw new EntityNotFoundException("Status");
            }
            Context.Statuses.Remove(status);
            Context.SaveChanges();
        }
    }
}
