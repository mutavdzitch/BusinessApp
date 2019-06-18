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
    public class ProjectsController : ControllerBase
    {
        private readonly IGetProjectsCommand _getCommand;
        private readonly IGetProjectCommand _getOneCommand;
        private readonly IAddProjectCommand _addCommand;
        private readonly IDeleteProjectCommand _deleteCommand;
        private readonly IEditProjectCommand _editCommand;

        public ProjectsController(
                IGetProjectsCommand getCommand,
                IGetProjectCommand getOneCommand,
                IAddProjectCommand addCommand,
                IDeleteProjectCommand deleteCommand,
                IEditProjectCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> Get([FromQuery]ProjectSearch search)
        {
            try
            {
                var projects = _getCommand.Execute(search);
                return Ok(projects);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/projects/5
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> Get(int id)
        {
            try
            {
                var projectDto = _getOneCommand.Execute(id);
                return Ok(projectDto);
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

        //Insert POST api/projects
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Project has been successfully added");
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

        //Update PUT api/projects/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Project has been successfully edited");
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

        // DELETE api/projects/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Project has been successfully deleted");
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