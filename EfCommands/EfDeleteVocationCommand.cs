using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteVocationCommand : BaseEfCommand, IDeleteVocationCommand
    {
        public EfDeleteVocationCommand(BusinessContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var vocation = Context.Vocations.Find(request);

            if(vocation == null)
            {
                throw new EntityNotFoundException("Vocation");
            }
            Context.Vocations.Remove(vocation);
            Context.SaveChanges();
        }
    }
}
