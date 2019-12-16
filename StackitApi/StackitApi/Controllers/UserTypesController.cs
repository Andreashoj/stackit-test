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
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;


        public UserTypesController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }


        // GET: api/usertypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserTypes()
        {
            var userTypes = await _userTypeService.GetAll();
            return Ok(userTypes);
        }


        // GET: api/usertypes/{userTypeId}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(int id)
        {
            var userType = await _userTypeService.GetById(id);

            if (userType == null)
                return NotFound();

            return Ok(userType);
        }


        // POST: api/usertypes
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType(UserType userType)
        {
            try
            {
                var newUserType = await _userTypeService.Create(userType);
                return Ok(newUserType);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/usertypes/{userTypeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(int id, UserType userType)
        {
            if (id != userType.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newUserType = await _userTypeService.Update(userType);
                return Ok(newUserType);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/usertypes/{userTypeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserType>> DeleteUserType(int id)
        {
            var userType = await _userTypeService.Delete(id);
            if (userType == null) return NotFound();
            else return Ok(userType);
        }
    }
}
