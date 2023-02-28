using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Level_up.Models;

namespace Level_up.Controllers
{
    public class LevelController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult Level(string name)
        {
            var cat = db.Categories.Where(n => n.Name == name).Select(n => n.Levels);
            return Ok(cat);
        }
    }
}
