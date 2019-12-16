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
    public class StacksController : ControllerBase
    {
        private readonly IStackService _stackService;


        public StacksController(IStackService stackService)
        {
            _stackService = stackService;
        }


        // GET: api/stacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stack>>> GetStacks()
        {
            var stacks = await _stackService.GetAll();
            return Ok(stacks);
        }


        // GET: api/stacks/{stackId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Stack>> GetStack(int id)
        {
            var stack = await _stackService.GetById(id);

            if (stack == null)
                return NotFound();

            return Ok(stack);
        }


        // GET: api/stacks/machines/{machineId}
        [HttpGet("machines/{id}")]
        public async Task<ActionResult<IEnumerable<Stack>>> GetStacksForMachine(int id)
        {
            var stacks = await _stackService.GetByMachineId(id);
            return Ok(stacks);
        }


        // POST: api/stacks
        [HttpPost]
        public async Task<ActionResult<Stack>> PostStack(Stack stack)
        {
            try
            {
                var newStack = await _stackService.Create(stack);
                return Ok(newStack);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/stacks/{stackId}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStack(int id, Stack stack)
        {
            if (id != stack.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newStack = await _stackService.Update(stack);
                return Ok(newStack);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/stacks/{stackId}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stack>> DeleteStack(int id)
        {
            var stack = await _stackService.Delete(id);
            if (stack == null) return NotFound();
            else return Ok(stack);
        }
    }
}
