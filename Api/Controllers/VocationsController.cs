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
    public class VocationsController : ControllerBase
    {
        private readonly IGetVocationsCommand _getCommand;
        private readonly IGetVocationCommand _getOneCommand;
        private readonly IAddVocationCommand _addCommand;
        private readonly IDeleteVocationCommand _deleteCommand;
        private readonly IEditVocationCommand _editCommand;

        public VocationsController(
                IGetVocationsCommand getCommand,
                IGetVocationCommand getOneCommand,
                IAddVocationCommand addCommand,
                IDeleteVocationCommand deleteCommand,
                IEditVocationCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/vocations
        [HttpGet]
        public ActionResult<IEnumerable<VocationDto>> Get([FromQuery]VocationSearch search)
        {
            try
            {
                var vocations = _getCommand.Execute(search);
                return Ok(vocations);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/vocations/5
        [HttpGet("{id}")]
        public ActionResult<VocationDto> Get(int id)
        {
            try
            {
                var vocationDto = _getOneCommand.Execute(id);
                return Ok(vocationDto);
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

        //Insert POST api/vocations
        [HttpPost]
        public IActionResult Post([FromBody] VocationDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Vocation has been successfully added");
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

        //Update PUT api/vocations/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VocationDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Vocation has been successfully edited");
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

        // DELETE api/vocations/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Vocation has been successfully deleted");
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