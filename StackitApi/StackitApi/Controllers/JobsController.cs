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
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;


        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }


        // GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            var jobs = await _jobService.GetAll();
            return Ok(jobs);
        }


        // GET: api/jobs/{jobId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _jobService.GetById(id);

            if (job == null)
                return NotFound();

            return Ok(job);
        }


        // GET: api/jobs/stacks/{stackId}
        [HttpGet("stacks/{id}")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobsForStack(int id)
        {
            var jobs = await _jobService.GetByStackId(id);
            return Ok(jobs);
        }


        // POST: api/jobs
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            try
            {
                var newJob = await _jobService.Create(job);
                return Ok(newJob);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/jobs/{jobId}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newJob = await _jobService.Update(job);
                return Ok(newJob);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/jobs/{jobId}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(int id)
        {
            var job = await _jobService.Delete(id);
            if (job == null) return NotFound();
            else return Ok(job);
        }
    }
}
