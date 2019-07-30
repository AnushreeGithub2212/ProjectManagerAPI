﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer;
using DataAccessLayer;

namespace ProjectManagerAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UserBusiness userBusiness = new UserBusiness();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return userBusiness.GetUsers();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = userBusiness.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                userBusiness.PutUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userBusiness.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userBusiness.PostUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = userBusiness.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            userBusiness.DeleteUser(user);

            return Ok(user);
        }

    }
}