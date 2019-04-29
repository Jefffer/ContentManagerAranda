using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private ContentManagerModel db = new ContentManagerModel();

        //public UserController()
        //{
        //    // Configuration... 
        //    db.Configuration.ProxyCreationEnabled = false;
        //    db.Configuration.LazyLoadingEnabled = false;
        //}

        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            IQueryable<User> users = db.User.Include(r => r.Role.Permission_Role); // Get users with Role
            return users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.User.Where(u => u.idUser == id).Include(r => r.Role).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/nickname&password
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string nickname, string password)
        {
            User user = db.User.Where(u => u.userNickname == nickname && u.userPassword == password).Include(r => r.Role.Permission_Role).FirstOrDefault();
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
            if (id != user.idUser)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
            db.User.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.idUser }, user);
        }

        // DELETE: api/Users/1
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.idUser == id) > 0;
        }
    }
}