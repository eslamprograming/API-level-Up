using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Level_up.Models;

namespace Level_up.Controllers
{
    public class CategoryController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult cat(string type)
        {
            var c = db.Categories.Where(n=>n.type==type).ToList();
            return Ok(c);
        }
        //[HttpPost]
        //public IHttpActionResult Addcat(string catname)
        //{
        //    //var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
        //    //int id = Convert.ToInt32(date[1].Value);
        //    int id = 2;
        //    User user = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
        //    var cat = db.Categories.Where(n => n.Name == catname).SingleOrDefault();
        //    if (cat == null) return BadRequest();
        //    Cat_Level_User clu = new Cat_Level_User();
        //    clu.u_ID = id;
        //    clu.ID = cat.ID;
        //    clu.User = user;
        //    clu.Category = cat;
        //    clu.L_ID = 1;
        //    clu.Level = db.Levels.Where(n => n.L_ID == 1).SingleOrDefault();
        //    db.Cat_Level_User.Add(clu);
        //    db.SaveChanges();
        //    return Ok();
        //}
    }
}
