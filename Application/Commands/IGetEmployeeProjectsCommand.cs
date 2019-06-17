﻿using Application.DataTransfer;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetEmployeeProjectsCommand : ICommand<EmployeeProjectSearch, IEnumerable<EmployeeProjectDto>>
    {
    }
}
