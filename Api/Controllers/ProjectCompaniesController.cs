using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Commands;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCompaniesController : ControllerBase
    {
        private readonly IGetProjectCompaniesCommand _getCommand;
        private readonly IGetProjectCompanyCommand _getOneCommand;
        private readonly IAddProjectCompanyCommand _addCommand;
        private readonly IDeleteProjectCompanyCommand _deleteCommand;

        public ProjectCompaniesController(
                IGetProjectCompaniesCommand getCommand,
                IGetProjectCompanyCommand getOneCommand,
                IAddProjectCompanyCommand addCommand,
                IDeleteProjectCompanyCommand deleteCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
        }

        // GET api/projectCompanies
        [HttpGet]
        public ActionResult<IEnumerable<ProjectCompanyDto>> Get([FromQuery]ProjectCompanySearch search)
        {
            try
            {
                var projectCompanies = _getCommand.Execute(search);
                return Ok(projectCompanies);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/projectCompanies/5
        [HttpGet("{id}")]
        public ActionResult<ProjectCompanyDto> Get(int id)
        {
            try
            {
                var projectCompanyDto = _getOneCommand.Execute(id);
                return Ok(projectCompanyDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        //Insert POST api/projectCompanies
        [HttpPost]
        public IActionResult Post([FromBody] ProjectCompanyDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "ProjectCompany has been successfully added");
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }


        // DELETE api/projectCompanies/5
        [HttpDelete]
        public IActionResult Delete([FromBody]DeleteProjectCompanyDto dto)
        {
            try
            {
                _deleteCommand.Execute(dto);
                return StatusCode(201, "ProjectCompany has been successfully deleted");
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }
    }
}