using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ShortbrainWeb.Dtos;
using ShortbrainWeb.Models;

namespace ShortbrainWeb.Controllers.Api
{
    public class UsersController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/users
        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users
                .Include(u => u.MembershipType)
                .ToList()
                .Select(Mapper.Map<User, UserDto>);
        }

        // GET /api/users/1
        public IHttpActionResult GetUser(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //return Mapper.Map<User, UserDto>(user);
            return Ok(Mapper.Map<User, UserDto>(user));
        }

        //POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.Id = user.Id;

            //return userDto;
            return Created(new Uri(Request.RequestUri + "/" + user.Id), userDto);
        }

        //PUT /api/users/1
        [HttpPut]
        public void UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(userDto, userInDb);
            //userInDb.Username = userDto.Username;
            //userInDb.Name = userDto.Name;
            //userInDb.Firstname = userDto.Firstname;
            //userInDb.Birthdate = userDto.Birthdate;
            //userInDb.Email = userDto.Email;
            //userInDb.IsSubscribedToNewsLetter = userDto.IsSubscribedToNewsLetter;
            //userInDb.MembershipTypeId = userDto.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }
    }
}
