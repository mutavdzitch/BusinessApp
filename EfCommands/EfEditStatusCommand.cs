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
    public class EfEditStatusCommand : BaseEfCommand, IEditStatusCommand
    {
        public EfEditStatusCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(StatusDto request)
        {
            var status = Context.Statuses.Find(request.Id);
            if (status == null)
            {
                throw new EntityNotFoundException("Status");
            }
            if (status.Value != request.Value)
            {
                if (Context.Statuses.Any(s => s.Value == request.Value))
                {
                    throw new EntityAlreadyExistsException("Status");
                }
                status.Value = request.Value;
            }
            Context.SaveChanges();
        }
    }
}
