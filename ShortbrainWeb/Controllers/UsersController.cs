﻿using System;
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new UserFormViewModel
            {
                User = new User(),
                MembershipTypes = membershipTypes

            };

            return View("UserForm", viewModel);
        }

        // GET: Users
        public ActionResult Index()
        {
            //var users = _context.Users.Include(c => c.MembershipType).ToList();

            //return View(users);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            Console.WriteLine(user);
            Console.WriteLine(user.Id);
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("UserForm", viewModel);
            }

            if (user.Id == 0)
                _context.Users.Add(user);
            else
            {
                var userInDb = _context.Users.Single(u => u.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.Username = user.Username;
                userInDb.Firstname = user.Firstname;
                userInDb.Email = user.Email;
                userInDb.IsSubscribedToNewsLetter = user.IsSubscribedToNewsLetter;
                userInDb.MembershipTypeId = user.MembershipTypeId;
            } 

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
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
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.Include(u => u.MembershipType).SingleOrDefault(u => u.Id == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel
            {
                User = user,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("UserForm", viewModel);

        }

    }
}