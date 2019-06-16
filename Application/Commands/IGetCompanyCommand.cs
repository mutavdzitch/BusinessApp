using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetCompanyCommand : ICommand<int, CompanyDto>
    {
    }
}
