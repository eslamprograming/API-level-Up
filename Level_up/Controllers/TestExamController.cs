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
    public class TestExamController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult Exam(string name)
        {
            Category cat = db.Categories.Where(n => n.Name == name).SingleOrDefault();
            if(cat == null)
            {
                return NotFound();
            }
            else
            {
                var E = db.Exams.Where(n => n.ID == cat.ID).ToList();
                
                

                return Ok(E);
            }
            
        }
        [HttpPost]
        public IHttpActionResult anserExam(string name, string[] ans)
        {
            //string[] ans = { "الإستاتيكا", "البرت اينشتاين", "Ford", "Mazda" };
            Category cat = db.Categories.Where(n => n.Name == name).SingleOrDefault();
            int c_id = cat.ID;
            var E = db.Exams.Where(n => n.ID == cat.ID).Select(n=>n.anseur).ToList();
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
            cat_E_u cat_E_U = new cat_E_u();
            cat_E_U.mark = degree;
            cat_E_U.u_ID = id;
            cat_E_U.ID = c_id;
            cat_E_U.Category = cat;
            cat_E_U.User = u;
            db.cat_E_u.Add(cat_E_U);
            db.SaveChanges();
            Cat_Level_User cul = new Cat_Level_User();
            cul.User = u;
            cul.u_ID = id;
            cul.ID = c_id;
            cul.Category = cat;
            if (degree <= 5)
            {
                //level 1

                cul.L_ID = 1;
                cul.Level = db.Levels.Where(n => n.L_ID == 1).SingleOrDefault();
                db.Cat_Level_User.Add(cul);
                db.SaveChanges();
            }
            else if(degree<=10&&degree>5)
            {
                //level 2

                cul.L_ID = 2;
                cul.Level = db.Levels.Where(n => n.L_ID == 2).SingleOrDefault();
                db.Cat_Level_User.Add(cul);
                db.SaveChanges();
            }
            else if(degree <= 10 && degree > 10)
            {
                //level 3

                cul.L_ID = 2;
                cul.Level = db.Levels.Where(n => n.L_ID == 2).SingleOrDefault();
                db.Cat_Level_User.Add(cul);
                db.SaveChanges();
            }
            else
            {
                //level 4

                cul.L_ID = 4;
                cul.Level = db.Levels.Where(n => n.L_ID == 4).SingleOrDefault();
                db.Cat_Level_User.Add(cul);
                db.SaveChanges();
            }
            return Ok(degree);
        }
    }
}
