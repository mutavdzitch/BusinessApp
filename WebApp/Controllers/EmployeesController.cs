using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
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

        // GET: Employees
        public ActionResult Index(EmployeeSearch search)
        {
            var result = _getCommand.Execute(search);
            return View(result);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var employeeDto = _getOneCommand.Execute(id);
                return View(employeeDto);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _addCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Emplpoyee with this email or username already exists.";
            }
            catch (Exception)
            {
                TempData["error"] = "An error has occured.";
            }

            return View();
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _getOneCommand.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                _editCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Emplpoyee with this email or username already exists.";
                return View(dto);
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var dto = _getOneCommand.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _deleteCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["error"] = "An error has occurred.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}