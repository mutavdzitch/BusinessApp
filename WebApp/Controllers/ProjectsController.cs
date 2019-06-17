using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Responses;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProjectsController : Controller
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

        // GET: Projects
        public ActionResult Index(ProjectSearch search)
        {
            var result = _getCommand.Execute(search);
            return View(result.Data);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var projectDto = _getOneCommand.Execute(id);
                return View(projectDto);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectDto dto)
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
            /*catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Kategorija sa istim imenom vec postoji.";
            }*/
            catch (Exception)
            {
                TempData["error"] = "An error has occured.";
            }

            return View();
        }

        // GET: Projects/Edit/5
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

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectDto dto)
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
            /*catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Kategorija sa istim imenom vec postoji.";
                return View(dto);
            }*/
        }

        // GET: Projects/Delete/5
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

        // POST: Projects/Delete/5
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