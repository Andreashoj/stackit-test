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
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;


        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }


        // GET: api/machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines()
        {
            var machines = await _machineService.GetAll();
            return Ok(machines);
        }


        // GET: api/machines/{machineId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMachine(int id)
        {
            var machine = await _machineService.GetById(id);

            if (machine == null)
                return NotFound();

            return Ok(machine);
        }


        // GET: api/machines/companies/{companyId}
        [HttpGet("companies/{id}")]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachinesForCompany(int id)
        {
            var machines = await _machineService.GetByCompanyId(id);
            return Ok(machines);
        }


        // POST: api/machines
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine)
        {
            try
            {
                var newMachine = await _machineService.Create(machine);
                return Ok(newMachine);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/machines/{machineId}
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(int id, Machine machine)
        {
            if (id != machine.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newMachine = await _machineService.Update(machine);
                return Ok(newMachine);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/machines/{machineId}
        //[Authorize(Roles = "S_Admin, K_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Machine>> DeleteMachine(int id)
        {
            var machine = await _machineService.Delete(id);
            if (machine == null) return NotFound();
            else return Ok(machine);
        }
    }
}
