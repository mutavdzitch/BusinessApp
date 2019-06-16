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
    public class StatusesController : ControllerBase
    {
        private readonly IGetStatusesCommand _getCommand;
        private readonly IGetStatusCommand _getOneCommand;
        private readonly IAddStatusCommand _addCommand;
        private readonly IDeleteStatusCommand _deleteCommand;
        private readonly IEditStatusCommand _editCommand;

        public StatusesController(
                IGetStatusesCommand getCommand,
                IGetStatusCommand getOneCommand,
                IAddStatusCommand addCommand,
                IDeleteStatusCommand deleteCommand,
                IEditStatusCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/statuses
        [HttpGet]
        public IActionResult Index([FromQuery]StatusSearch search)
        {
            try
            {
                var statuses = _getCommand.Execute(search);
                return Ok(statuses);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/statuses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var statusDto = _getOneCommand.Execute(id);
                return Ok(statusDto);
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

        //Insert POST api/statuses
        [HttpPost]
        public IActionResult Post([FromBody] StatusDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
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

        //Update PUT api/statuses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Status has been successfully edited");
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
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

        // DELETE api/statuses/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Status has been successfully deleted");
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