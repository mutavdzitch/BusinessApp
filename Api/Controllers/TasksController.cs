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
    public class TasksController : ControllerBase
    {
        private readonly IGetTasksCommand _getCommand;
        private readonly IGetTaskCommand _getOneCommand;
        private readonly IAddTaskCommand _addCommand;
        private readonly IDeleteTaskCommand _deleteCommand;
        private readonly IEditTaskCommand _editCommand;

        public TasksController(
                IGetTasksCommand getCommand,
                IGetTaskCommand getOneCommand,
                IAddTaskCommand addCommand,
                IDeleteTaskCommand deleteCommand,
                IEditTaskCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> Get([FromQuery]TaskSearch search)
        {
            try
            {
                var tasks = _getCommand.Execute(search);
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var taskDto = _getOneCommand.Execute(id);
                return Ok(taskDto);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        //Insert POST api/tasks
        [HttpPost]
        public IActionResult Post([FromBody] TaskDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Task has been successfully added");
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

        //Update PUT api/tasks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Task has been successfully edited");
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

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Task has been successfully deleted");
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