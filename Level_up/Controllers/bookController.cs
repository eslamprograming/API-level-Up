using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.ModelBinding;
using Level_up.Models;

namespace Level_up.Controllers
{
    public class bookController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult Res(string catname,string levname)
        {
            ////////////get user by JWT
            //var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
            //int id = Convert.ToInt32(date[1].Value);
            ////int id = 1;
            //User user = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
            //if (user == null)
            //{
            //    return StatusCode(HttpStatusCode.Unauthorized);
            //}
            //var c = db.has_R.Where(n=>n.Category.Name == catname & n.Level.name == levname).SingleOrDefault();

            //if (c == null)
            //{
            //    return Ok("this user can not get this books");
            //}

            var book = db.has_R.Where(n => n.Category.Name == catname & n.Level.name == levname).Select(n=>n.Resource.R_book).ToList();
            

            return Ok(book);
        }
    }
}
