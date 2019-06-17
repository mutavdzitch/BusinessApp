using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IDeleteEmployeeCommand : ICommand<int>
    {
    }
}
