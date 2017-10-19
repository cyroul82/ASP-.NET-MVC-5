using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShortbrainWeb.Models;
using ShortbrainWeb.ViewModels;

namespace ShortbrainWeb.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = _context.Users.Include(c => c.MembershipType).ToList();

            //var users = Get
            return View(users);
        }

    }
}