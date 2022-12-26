using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TodoServices.Data;
using TodoServices.Model;
using TodoServices.Tools;

namespace TodoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> UserLogin([FromBody] User user)
        {
            string password = Password.hashPassword(user.Password);
           var dbUser= _context.Users.Where(u=>u.UserName == user.UserName && u.Password == password).FirstOrDefault();

            if(dbUser==null)
            {
                return BadRequest("Username or Password Incorect");
            }
            return Ok(dbUser);
             
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> UserRegistration([FromBody]User user)
        {
            var dbUser = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if(dbUser != null)
            {
                return BadRequest("Username already exist");
            }
            
            user.Password = Password.hashPassword(user.Password);
            user.Active = 1;

            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return Ok("User Successfully Registered");
        }

    }
}
