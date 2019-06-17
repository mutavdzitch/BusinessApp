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
    public class EfAddStatusCommand : BaseEfCommand, IAddStatusCommand
    {
        public EfAddStatusCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(StatusDto request)
        {
            if (Context.Statuses.Any(s => s.Value == request.Value))
            {
                throw new EntityAlreadyExistsException("Status");
            }

            Context.Statuses.Add(new Domain.Status
            {
                Value = request.Value
            });
            Context.SaveChanges();
        }
    }
}
