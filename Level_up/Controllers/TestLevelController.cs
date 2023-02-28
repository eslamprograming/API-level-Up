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
    public class TestLevelController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult test(string catname, string levname)
        {
            var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
            int id = Convert.ToInt32(date[1].Value);
            //int id = 1;
            User user = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
            if (user == null)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            int l_id = db.Levels.Where(n => n.name == levname).Select(n => n.L_ID).SingleOrDefault();
            int c_id = db.Categories.Where(n => n.Name == catname).Select(n => n.ID).SingleOrDefault();

            var e = db.Cat_Level_User.Where(n => n.u_ID == id&n.ID==c_id).Select(n => n.L_ID).ToList();
            var c = db.Cat_Level_User.Where(n => n.u_ID == id & n.Category.ID == c_id & n.Level.L_ID == l_id).SingleOrDefault();
            foreach (var item in e)
            {
                if (item < l_id)
                {
                    return Ok("this test he can not enter");
                }
            }
            if (c==null)
            {
                Cat_Level_User clu = new Cat_Level_User();
                clu.u_ID = id;
                clu.ID = c_id;
                clu.L_ID = 1;
                db.Cat_Level_User.Add(clu);
                db.SaveChanges();
                var test1 = db.Cat_Level_Quction.Where(n => n.Category.Name == catname & n.Level.L_ID == 1).ToList();
                return Ok(test1);
               
            }

            var test = db.Cat_Level_Quction.Where(n => n.Category.Name == catname & n.Level.name == levname).ToList();


            return Ok(test);
        }
        public IHttpActionResult anserExam(string name, string lev, string[] ans)
        {
            Category cat = db.Categories.Where(n => n.Name == name).SingleOrDefault();
            int c_id = cat.ID;
            Level le = db.Levels.Where(n => n.name == lev).SingleOrDefault();
            int l_id = le.L_ID;
            var E = db.Cat_Level_Quction.Where(n => n.ID == cat.ID & n.L_ID == l_id).Select(n => n.Quction.anseur).ToList();
            var date = ((ClaimsIdentity)User.Identity).Claims.ToList();
            int id = Convert.ToInt32(date[1].Value);
            User u = db.Users.Where(n => n.u_ID == id).SingleOrDefault();
            int degree = 0;
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] == E[i])
                {
                    degree+=5;
                }

            }
            Degree d = new Degree();
            d.Mark = degree;
            db.Degrees.Add(d);


            db.SaveChanges();
            user_degree cul = new user_degree();
            cul.User = u;
            cul.u_ID = id;
            cul.ID = c_id;
            cul.D_ID = d.D_ID;
            cul.Degree = d;
            cul.Category = cat;


            
            if (l_id == 4&&degree>=10)
            {
                return Ok("finished");
            }
            if (degree >= 10)
            {
                //level 1


                cul.L_ID = l_id + 1;
                cul.Level = db.Levels.Where(n => n.L_ID == l_id + 1).SingleOrDefault();

                db.user_degree.Add(cul);
                db.SaveChanges();
            }

            return Ok(degree);
        }
    }
}
