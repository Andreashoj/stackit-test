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
    public class PrivilegesController : ControllerBase
    {
        private readonly IPrivilegeService _privilegeService;


        public PrivilegesController(IPrivilegeService privilegeService)
        {
            _privilegeService = privilegeService;
        }


        // GET: api/privileges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Privilege>>> GetPrivileges()
        {
            var privileges = await _privilegeService.GetAll();
            return Ok(privileges);
        }


        // GET: api/privileges/{privilegeId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Privilege>> GetPrivilege(int id)
        {
            var privilege = await _privilegeService.GetById(id);

            if (privilege == null)
                return NotFound();

            return Ok(privilege);
        }


        // POST: api/privileges
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<Privilege>> PostPrivilege(Privilege privilege)
        {
            try
            {
                var newPrivilege = await _privilegeService.Create(privilege);
                return Ok(newPrivilege);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/privileges/{privilegeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivilege(int id, Privilege privilege)
        {
            if (id != privilege.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newPrivilege = await _privilegeService.Update(privilege);
                return Ok(newPrivilege);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/privileges/{privilegeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Privilege>> DeletePrivilege(int id)
        {
            var privilege = await _privilegeService.Delete(id);
            if (privilege == null) return NotFound();
            else return Ok(privilege);
        }
    }
}
