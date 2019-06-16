using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class BaseEfCommand
    {
        protected BusinessContext Context { get; set; }
        protected BaseEfCommand(BusinessContext context) => Context = context;
    }
}
