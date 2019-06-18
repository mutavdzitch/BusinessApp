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
    public class EmployeeProjectsController : ControllerBase
    {
        private readonly IGetEmployeeProjectsCommand _getCommand;
        private readonly IGetEmployeeProjectCommand _getOneCommand;
        private readonly IAddEmployeeProjectCommand _addCommand;
        private readonly IDeleteEmployeeProjectCommand _deleteCommand;

        public EmployeeProjectsController(
                IGetEmployeeProjectsCommand getCommand,
                IGetEmployeeProjectCommand getOneCommand,
                IAddEmployeeProjectCommand addCommand,
                IDeleteEmployeeProjectCommand deleteCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
        }

        // GET api/employeeProjects
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeProjectDto>> Get([FromQuery]EmployeeProjectSearch search)
        {
            try
            {
                var employeeProjects = _getCommand.Execute(search);
                return Ok(employeeProjects);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/employeeProjects/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeProjectDto> Get(int id)
        {
            try
            {
                var employeeProjectDto = _getOneCommand.Execute(id);
                return Ok(employeeProjectDto);
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

        //Insert POST api/employeeProjects
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeProjectDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "EmployeeProject has been successfully added");
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

        // DELETE api/employeeProjects/5
        [HttpDelete]
        public IActionResult Delete([FromBody]DeleteEmployeeProjectDto dto)
        {
            try
            {
                _deleteCommand.Execute(dto);
                return StatusCode(201, "EmployeeProject has been successfully deleted");
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
