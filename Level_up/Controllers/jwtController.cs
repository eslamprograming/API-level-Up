using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Level_up.Models;


namespace Level_up.Controllers
{
    public class jwtController : ApiController
    {
        database db = new database();
        [HttpGet]
        public IHttpActionResult login(string email,string password)
        {
            User u = db.Users.Where(n => n.email == email & n.password == password).SingleOrDefault();
            if (u == null)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
            else
            {
                string key = "my_secret_key_12345"; //Secret key which will be used later during validation       

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    
                var date = new List<Claim>();
                date.Add(new Claim("email", email));
                date.Add(new Claim("userid", u.u_ID.ToString()));
                date.Add(new Claim("password", password));

                //Create Security Token object by giving required parameters    
                var token = new JwtSecurityToken(  
                                   
                             claims: date,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { date = jwt_token });

            }
        }
    }
}
