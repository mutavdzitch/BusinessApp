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
    public class CitiesController : ControllerBase
    {
        private readonly IGetCitiesCommand _getCommand;
        private readonly IGetCityCommand _getOneCommand;
        private readonly IAddCityCommand _addCommand;
        private readonly IDeleteCityCommand _deleteCommand;
        private readonly IEditCityCommand _editCommand;

        public CitiesController(
                IGetCitiesCommand getCommand,
                IGetCityCommand getOneCommand,
                IAddCityCommand addCommand,
                IDeleteCityCommand deleteCommand,
                IEditCityCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/cities
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> Get([FromQuery]CitySearch search)
        {
            try
            {
                var cities = _getCommand.Execute(search);
                return Ok(cities);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/cities/5
        [HttpGet("{id}")]
        public ActionResult<CityDto> Get(int id)
        {
            try
            {
                var cityDto = _getOneCommand.Execute(id);
                return Ok(cityDto);
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

        //Insert POST api/cities
        [HttpPost]
        public IActionResult Post([FromBody] CityDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "City has been successfully added");
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

        //Update PUT api/cities/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CityDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "City has been successfully edited");
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

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "City has been successfully deleted");
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