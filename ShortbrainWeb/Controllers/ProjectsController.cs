using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShortbrainWeb.Models;
using ShortbrainWeb.ViewModels;

namespace ShortbrainWeb.Controllers
{
    public class ProjectsController : Controller
    {

        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = _context.Projects.Include(p => p.Category).ToList();

            return View(projects);
        }

        public ActionResult Detail(int id)
        {
            var project = _context.Projects.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                return View(project);
            }
            else
            {
                return Content("ID not found !");
            }
        }

        public ActionResult New()
        {
            var viewModel = new ProjectFormViewModel
            {
                Categories = _context.Categories.ToList()
            };


            return View("ProjectForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var project = _context.Projects.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            

            if (project == null)
                return HttpNotFound();

            var viewModel = new ProjectFormViewModel
            {
                Project = project,
                Categories = _context.Categories.ToList()
            };


            return View("ProjectForm", viewModel);
        }

        public ActionResult Save(Project project)
        {
            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDB = _context.Projects.Include(p => p.Category).Single(p => p.Id == project.Id);
                projectInDB.Category = project.Category;
                projectInDB.Date = project.Date;
                projectInDB.Description = project.Description;
                projectInDB.Name = project.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
    }
}