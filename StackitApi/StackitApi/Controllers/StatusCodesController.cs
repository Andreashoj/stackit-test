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
    public class StatusCodesController : ControllerBase
    {
        private readonly IStatusCodeService _statusCodeService;


        public StatusCodesController(IStatusCodeService statusCodeService)
        {
            _statusCodeService = statusCodeService;
        }


        // GET: api/statuscodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusCode>>> GetStatusCodes()
        {
            var statusCodes = await _statusCodeService.GetAll();
            return Ok(statusCodes);
        }


        // GET: api/statuscodes/{statusCodeId}
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusCode>> GetStatusCode(int id)
        {
            var statusCode = await _statusCodeService.GetById(id);

            if (statusCode == null)
                return NotFound();

            return Ok(statusCode);
        }


        // POST: api/statuscodes
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<StatusCode>> PostStatusCode(StatusCode statusCode)
        {
            try
            {
                var newStatusCode = await _statusCodeService.Create(statusCode);
                return Ok(newStatusCode);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/statuscodes/{statusCodeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusCode(int id, StatusCode statusCode)
        {
            if (id != statusCode.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newStatusCode = await _statusCodeService.Update(statusCode);
                return Ok(newStatusCode);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/statuscodes/{statusCodeId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusCode>> DeleteStatusCode(int id)
        {
            var statusCode = await _statusCodeService.Delete(id);
            if (statusCode == null) return NotFound();
            else return Ok(statusCode);
        }
    }
}
