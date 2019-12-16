using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackitApi.Models;
using StackitApi.Services;

namespace StackitApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;


        public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }


        // POST: api/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate([FromBody]User login)
        {
            var user = await _userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }


        // GET: api/users/{userId}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


        // GET api/users/usertypes/{userTypeId}
        [HttpGet("usertypes/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetByUserTypeId(int id)
        {
            var users = await _userService.GetByUserTypeId(id);
            return Ok(users);
        }


        // GET api/users/companies/{companyId}
        [HttpGet("companies/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetByCompanyId(int id)
        {
            var users = await _userService.GetByCompanyId(id);
            return Ok(users);
        }


        // POST: api/users
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                var newUser = await _userService.Create(user);
                return Ok(newUser);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/users/{userId}
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User newUser)
        {
            if (id != newUser.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var user = await _userService.Update(newUser);
                return Ok(user);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/users/{userId}
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.Delete(id);
            if (user == null) return NotFound();
            else return Ok(user);
        }
    }
}
