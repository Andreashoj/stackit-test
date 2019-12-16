using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackitApi.Models;
using StackitApi.Services;

namespace StackitApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultPrivilegesController : ControllerBase
    {
        private readonly IDefaultPrivilegeService _defaultPrivilegeService;


        public DefaultPrivilegesController(IDefaultPrivilegeService defaultPrivilegeService)
        {
            _defaultPrivilegeService = defaultPrivilegeService;
        }


        // GET: api/defaultprivileges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DefaultPrivilege>>> GetDefaultPrivileges()
        {
            var defaultPrivileges = await _defaultPrivilegeService.GetAll();
            return Ok(defaultPrivileges);
        }


        // GET: api/defaultprivileges/usertype/{userTypeId}/privilege/{privilegeId}
        [HttpGet("usertype/{userTypeId}/privilege/{privilegeId}")]
        public async Task<ActionResult<DefaultPrivilege>> GetDefaultPrivilege(int userTypeId, int privilegeId)
        {
            var defaultPrivilege = await _defaultPrivilegeService.GetById(userTypeId, privilegeId);

            if (defaultPrivilege == null)
            {
                return NotFound();
            }

            return defaultPrivilege;
        }


        // GET: api/defaultprivileges/usertype/{userTypeId}
        [HttpGet("usertype/{id}")]
        public async Task<ActionResult<IEnumerable<DefaultPrivilege>>> GetPrivilegesForUserType(int id)
        {
            var defaultPrivileges = await _defaultPrivilegeService.GetByUserTypeId(id);
            return Ok(defaultPrivileges);
        }


        // GET: api/defaultprivileges/privilege/{privilegeId}
        [HttpGet("privilege/{id}")]
        public async Task<ActionResult<IEnumerable<DefaultPrivilege>>> GetUserTypesForPrivilege(int id)
        {
            var defaultPrivileges = await _defaultPrivilegeService.GetByPrivilegeId(id);
            return Ok(defaultPrivileges);
        }


        // POST: api/defaultprivileges
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<DefaultPrivilege>> PostDefaultPrivilege(DefaultPrivilege defaultPrivilege)
        {
            try
            {
                var newDefaultPrivilege = await _defaultPrivilegeService.Create(defaultPrivilege);
                return Ok(newDefaultPrivilege);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/defaultprivileges/usertype/{userTypeId}/privilege/{privilegeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("usertype/{userTypeId}/privilege/{privilegeId}")]
        public async Task<ActionResult<DefaultPrivilege>> DeleteDefaultPrivilege(int userTypeId, int privilegeId)
        {
            var defaultPrivilege = await _defaultPrivilegeService.Delete(userTypeId, privilegeId);
            if (defaultPrivilege == null) return NotFound();
            else return Ok(defaultPrivilege);
        }
    }
}
