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

        public ActionResult Detail(int id)
        {
            
            var user = _context.Users.Include(u => u.MembershipType).SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return Content("User does not exist with this id");
            }
        }

    }
}