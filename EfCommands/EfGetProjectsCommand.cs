using Application.Commands;
using Application.DataTransfer;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetProjectsCommand : BaseEfCommand, IGetProjectsCommand
    {
        public EfGetProjectsCommand(BusinessContext context) : base(context)
        {

        }
        public PagedResponse<ProjectDto> Execute(ProjectSearch request)
        {
            var query = Context.Projects.AsQueryable();

            if(request.Title != null)
            {
                var keyword = request.Title.ToLower();
                query = query.Where(p => p.Title.ToLower().Contains(keyword));
            }

            if (request.StartDateOf != null)
            {
                query = query.Where(p => p.StartDate >= request.StartDateOf);
            }
            if (request.StartDateTo != null)
            {
                query = query.Where(p => p.StartDate <= request.StartDateTo);
            }
            if (request.EndDateOf != null)
            {
                query = query.Where(p => p.EndDate >= request.EndDateOf);
            }
            if (request.EndDateTo != null)
            {
                query = query.Where(p => p.EndDate <= request.EndDateTo);
            }

            if (request.StatusId != null)
            {
                query = query.Where(p => p.StatusId == request.StatusId);
            }

            if(request.CompanyId != null)
            {
                query = query.Where(p => p.ProjectCompanies.Any(pc => pc.CompanyId == request.CompanyId));
            }
            if(request.EmployeeId != null)
            {
                query = query.Where(p => p.ProjectEmployees.Any(pe => pe.EmployeeId == request.EmployeeId));
            }
            if (request.TaskEmployeeId != null)
            {
                query = query.Where(e => e.ProjectTasks.Any(t => t.EmployeeId == request.TaskEmployeeId));
            }

            //Pagination

            var totalCount = query.Count();

            query = query
                .Include(e => e.ProjectEmployees)
                .ThenInclude(ep => ep.Employee).Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            query = query
                .Include(e => e.ProjectTasks)
                .ThenInclude(t => t.Employee).Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            query = query
                .Include(e => e.ProjectCompanies)
                .ThenInclude(t => t.Company).Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponse<ProjectDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    StatusId = p.Status.Id,
                    StatusValue = p.Status.Value,
                    CompanyNames = p.ProjectCompanies.Select(pc => pc.Company.Name),
                    EmployeeNames = p.ProjectEmployees.Select(pc => pc.Employee.FirstName + ' ' + pc.Employee.LastName),
                    TaskNames = p.ProjectTasks.Select(t => t.Title)
                })
            };

            return response;
        }
    }
}
