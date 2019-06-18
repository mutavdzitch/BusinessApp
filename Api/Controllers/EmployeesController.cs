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
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployeesCommand _getCommand;
        private readonly IGetEmployeeCommand _getOneCommand;
        private readonly IAddEmployeeCommand _addCommand;
        private readonly IDeleteEmployeeCommand _deleteCommand;
        private readonly IEditEmployeeCommand _editCommand;

        public EmployeesController(
                IGetEmployeesCommand getCommand,
                IGetEmployeeCommand getOneCommand,
                IAddEmployeeCommand addCommand,
                IDeleteEmployeeCommand deleteCommand,
                IEditEmployeeCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get([FromQuery]EmployeeSearch search)
        {
            try
            {
                var employees = _getCommand.Execute(search);
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get(int id)
        {
            try
            {
                var employeeDto = _getOneCommand.Execute(id);
                return Ok(employeeDto);
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

        //Insert POST api/employees
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Employee has been successfully added");
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

        //Update PUT api/employees/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Employee has been successfully edited");
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

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Employee has been successfully deleted");
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
