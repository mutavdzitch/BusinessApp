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
    public class EfEditVocationCommand : BaseEfCommand, IEditVocationCommand
    {
        public EfEditVocationCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(VocationDto request)
        {
            var vocation = Context.Vocations.Find(request.Id);
            if(vocation == null)
            {
                throw new EntityNotFoundException("Vocation");
            }
            if (vocation.Name != request.Name)
            {
                if (Context.Vocations.Any(v => v.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("Vocation");
                }
                vocation.Name = request.Name;
            }
            Context.SaveChanges();
        }
    }
}
