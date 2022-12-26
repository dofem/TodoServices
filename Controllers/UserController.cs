using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoServices.Data;
using TodoServices.DTO;
using TodoServices.Model;
using TodoServices.Profiles.Data;
using TodoServices.Tools;

namespace TodoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public UserController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> UserLogin([FromBody] Login login)
        {
            string password = Password.hashPassword(login.Password);
           var dbUser= _context.Users.Where(u=>u.UserName == login.UserName && u.Password == password).FirstOrDefault();

            if(dbUser==null)
            {
                return BadRequest("Username or Password Incorect");
            }
            var dbuse =  _mapper.Map<User>(dbUser);
            return Ok("Login is Successful");
             
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> UserRegistration([FromBody]Register register)
        {
            var dbUser = _context.Users.Where(u => u.UserName == register.UserName).FirstOrDefault();
            if(dbUser != null)
            {
                return BadRequest("Username already exist");
            }
            
            register.Password = Password.hashPassword(register.Password);
            var registered = _mapper.Map<User>(register);

            _context.Users.Add(registered);
            await _context.SaveChangesAsync();

            return Ok("User Successfully Registered");
        }

    }
}
