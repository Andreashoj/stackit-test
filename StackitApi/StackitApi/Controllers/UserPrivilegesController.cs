using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;
using StackitApi.Services;

namespace StackitApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPrivilegesController : ControllerBase
    {
        private readonly IUserPrivilegeService _userPrivilegeService;


        public UserPrivilegesController(IUserPrivilegeService userPrivilegeService)
        {
            _userPrivilegeService = userPrivilegeService;
        }


        // GET: api/userprivileges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPrivilege>>> GetUserPrivileges()
        {
            var userPrivileges = await _userPrivilegeService.GetAll();
            return Ok(userPrivileges);
        }


        // GET: api/userprivileges/user/{userId}/privilege/{privilegeId}
        [HttpGet("user/{userId}/privilege/{privilegeId}")]
        public async Task<ActionResult<UserPrivilege>> GetUserPrivilege(int userId, int privilegeId)
        {
            var userPrivilege = await _userPrivilegeService.GetById(userId, privilegeId);

            if (userPrivilege == null)
            {
                return NotFound();
            }

            return userPrivilege;
        }


        // GET: api/userprivileges/user/{userId}
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<UserPrivilege>>> GetPrivilegesForUser(int id)
        {
            var userPrivileges = await _userPrivilegeService.GetByUserId(id);
            return Ok(userPrivileges);
        }


        // GET: api/userprivileges/privilege/{privilegeId}
        [HttpGet("privilege/{id}")]
        public async Task<ActionResult<IEnumerable<UserPrivilege>>> GetUsersForPrivilege(int id)
        {
            var userPrivileges = await _userPrivilegeService.GetByPrivilegeId(id);
            return Ok(userPrivileges);
        }


        // POST: api/userprivileges
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<UserPrivilege>> PostUserPrivilege(UserPrivilege userPrivilege)
        {
            try
            {
                var newUserPrivilege = await _userPrivilegeService.Create(userPrivilege);
                return Ok(newUserPrivilege);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/userprivileges/user/{userId}/privilege/{privilegeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("user/{userId}/privilege/{privilegeId}")]
        public async Task<ActionResult<UserPrivilege>> DeleteUserPrivilege(int userId, int privilegeId)
        {
            var userPrivilege = await _userPrivilegeService.Delete(userId, privilegeId);
            if (userPrivilege == null) return NotFound();
            else return Ok(userPrivilege);
        }
    }
}
