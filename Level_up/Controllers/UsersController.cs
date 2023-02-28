using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using Level_up.Models;

namespace Level_up.Controllers
{
    public class UsersController : ApiController
    {
        private database db = new database();

        // GET: api/Users
        //public IQueryable<User> GetUsers()
        //{
        //    return db.Users;
        //}

        // GET: api/Users
        [ResponseType(typeof(User))]
        [HttpGet]
        public IHttpActionResult GetUser()
        {

            var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
            int id = Convert.ToInt32(date[1].Value);
            User user = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //// PUT: api/Users
        //[ResponseType(typeof(void))]
        //[Authorize]
        //[HttpPut]
        //[Route("edit")]
        //public IHttpActionResult PutUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
        //    int id = Convert.ToInt32(date[1].Value);
        //    //if (id != user.u_ID)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        //[HttpPut]
        //public IHttpActionResult change(string oldpassword, string newpassword)
        //{
        //    var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
        //    int id = Convert.ToInt32(date[1].Value);
        //    var u = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
        //    if (u.password == oldpassword)
        //    {
        //        u.password = newpassword;
        //        db.SaveChanges();
        //        return Ok("changed");
        //    }
        //    else return Ok("password is not correct");
        //}

        // POST: api/AddUser
        //[ResponseType(typeof(User))]
        //[Route("api/AddUser")]
        //public IHttpActionResult PostUser(User user)
        //{
        //    if (db.Users.Where(n => n.e_mail == user.e_mail) != null) { return Ok("this E-mail is not valid"); }
        //    if (db.Users.Where(n => n.name == user.name&n.password==user.password) != null) { return Ok("change your password"); }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(user);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = user.u_ID }, user);
        //}


        // POST: api/AddUser
        [HttpPost]
        [Route("api/AddUser")]
        public IHttpActionResult PostUser(string first_name,string last_name,string password,string email,int age)
        {
            var u = db.Users.Where(n => n.email == email).SingleOrDefault();
           if (u!=null)  return Ok("this E-mail is Exit"); 
           

            User user = new User();
            user.first_name = first_name;
            user.last_name = last_name;
            user.password = password;
            user.email = email;
            user.age=age;
           

            db.Users.Add(user);
            db.SaveChanges();
            

            return Created(" ",user);
        }


        //// DELETE: api/Users/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult DeleteUser(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    db.SaveChanges();

        //    return Ok(user);
        //}

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
            return db.Users.Count(e => e.u_ID == id) > 0;
        }
    }
}