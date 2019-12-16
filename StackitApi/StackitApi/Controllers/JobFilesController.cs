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
    public class JobFilesController : ControllerBase
    {
        private readonly IJobFileService _jobFileService;


        public JobFilesController(IJobFileService jobFileService)
        {
            _jobFileService = jobFileService;
        }


        // GET: api/jobfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobFile>>> GetJobFiles()
        {
            var jobFiles = await _jobFileService.GetAll();
            return Ok(jobFiles);
        }


        // GET: api/jobfiles/job/{jobId}/file/{fileId}
        [HttpGet("job/{jobId}/file/{fileId}")]
        public async Task<ActionResult<JobFile>> GetJobFile(int jobId, int fileId)
        {
            var jobFile = await _jobFileService.GetById(jobId, fileId);

            if (jobFile == null)
            {
                return NotFound();
            }

            return jobFile;
        }


        // GET: api/jobfiles/job/{jobId}
        [HttpGet("job/{id}")]
        public async Task<ActionResult<IEnumerable<JobFile>>> GetFilesForJob(int id)
        {
            var jobFiles = await _jobFileService.GetByJobId(id);
            return Ok(jobFiles);
        }


        // GET: api/jobfiles/file/{fileId}
        [HttpGet("file/{id}")]
        public async Task<ActionResult<IEnumerable<JobFile>>> GetJobsForFile(int id)
        {
            var jobFiles = await _jobFileService.GetByFileId(id);
            return Ok(jobFiles);
        }


        // POST: api/jobfiles
        [HttpPost]
        public async Task<ActionResult<JobFile>> PostJobFile(JobFile jobFile)
        {
            try
            {
                var newJobFile = await _jobFileService.Create(jobFile);
                return Ok(newJobFile);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/jobfiles/job/{jobId}/file/{fileId}
        [HttpDelete("job/{jobId}/file/{fileId}")]
        public async Task<ActionResult<JobFile>> DeleteJobFile(int jobId, int fileId)
        {
            var jobFile = await _jobFileService.Delete(jobId, fileId);
            if (jobFile == null) return NotFound();
            else return Ok(jobFile);
        }
    }
}
