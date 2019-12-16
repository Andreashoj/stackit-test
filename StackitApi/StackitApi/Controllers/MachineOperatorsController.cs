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
    public class MachineOperatorsController : ControllerBase
    {
        private readonly IMachineOperatorService _machineOperatorService;


        public MachineOperatorsController(IMachineOperatorService machineOperatorService)
        {
            _machineOperatorService = machineOperatorService;
        }


        // GET: api/machineoperators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineOperator>>> GetMachineOperators()
        {
            var machineOperators = await _machineOperatorService.GetAll();
            return Ok(machineOperators);
        }


        // GET: api/machineoperators/user/{userId}/machine/{machineId}
        [HttpGet("user/{userId}/machine/{machineId}")]
        public async Task<ActionResult<MachineOperator>> GetMachineOperator(int userId, int machineId)
        {
            var machineOperator = await _machineOperatorService.GetById(userId, machineId);

            if (machineOperator == null)
            {
                return NotFound();
            }

            return machineOperator;
        }


        // GET: api/machineoperators/machine/{machineId}
        [HttpGet("machine/{id}")]
        public async Task<ActionResult<IEnumerable<MachineOperator>>> GetMachineOperators(int id)
        {
            var machineOperators = await _machineOperatorService.GetByMachineId(id);
            return Ok(machineOperators);
        }


        // GET: api/machineoperators/user/{userId}
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<MachineOperator>>> GetOperatedMachines(int id)
        {
            var machineOperators = await _machineOperatorService.GetByUserId(id);
            return Ok(machineOperators);
        }


        // POST: api/machineoperators
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpPost]
        public async Task<ActionResult<MachineOperator>> PostMachineOperator(MachineOperator machineOperator)
        {
            try
            {
                var newMachineOperator = await _machineOperatorService.Create(machineOperator);
                return Ok(newMachineOperator);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/machineoperators/user/{userId}/machine/{machineId}
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpDelete("user/{userId}/machine/{machineId}")]
        public async Task<ActionResult<MachineOperator>> DeleteMachineOperator(int userId, int machineId)
        {
            var machineOperator = await _machineOperatorService.Delete(userId, machineId);
            if (machineOperator == null) return NotFound();
            else return Ok(machineOperator);
        }
    }
}
