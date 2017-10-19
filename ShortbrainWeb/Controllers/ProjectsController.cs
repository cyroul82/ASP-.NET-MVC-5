﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShortbrainWeb.Models;

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
    }
}