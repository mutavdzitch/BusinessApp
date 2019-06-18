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
    public class CompaniesController : ControllerBase
    {
        private readonly IGetCompaniesCommand _getCommand;
        private readonly IGetCompanyCommand _getOneCommand;
        private readonly IAddCompanyCommand _addCommand;
        private readonly IDeleteCompanyCommand _deleteCommand;
        private readonly IEditCompanyCommand _editCommand;

        public CompaniesController(
                IGetCompaniesCommand getCommand,
                IGetCompanyCommand getOneCommand,
                IAddCompanyCommand addCommand,
                IDeleteCompanyCommand deleteCommand,
                IEditCompanyCommand editCommand
            )
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _deleteCommand = deleteCommand;
            _editCommand = editCommand;
        }

        // GET api/companies
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDto>> Get([FromQuery]CompanySearch search)
        {
            try
            {
                var companies = _getCommand.Execute(search);
                return Ok(companies);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // GET api/companies/5
        [HttpGet("{id}")]
        public ActionResult<CompanyDto> Get(int id)
        {
            try
            {
                var companyDto = _getOneCommand.Execute(id);
                return Ok(companyDto);
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

        //Insert POST api/companies
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto dto)
        {
            try
            {
                _addCommand.Execute(dto);
                return StatusCode(201, "Company has been successfully added");
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

        //Update PUT api/companies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommand.Execute(dto);
                return StatusCode(201, "Company has been successfully edited");
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

        // DELETE api/companies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return StatusCode(201, "Company has been successfully deleted");
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