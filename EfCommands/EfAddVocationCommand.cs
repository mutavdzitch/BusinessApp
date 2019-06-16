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
    public class EfAddVocationCommand : BaseEfCommand, IAddVocationCommand
    {
        public EfAddVocationCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(VocationDto request)
        {
            if(Context.Vocations.Any(v => v.Name == request.Name))
            {
                throw new EntityAlreadyExistsException("Vocation");
            }

            Context.Vocations.Add(new Domain.Vocation
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
