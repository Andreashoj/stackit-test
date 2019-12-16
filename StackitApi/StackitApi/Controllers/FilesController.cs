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
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;


        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }


        // GET: api/files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetFiles()
        {
            var files = await _fileService.GetAll();
            return Ok(files);
        }


        // GET: api/files/{fileId}
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFile(int id)
        {
            var file = await _fileService.GetById(id);

            if (file == null)
                return NotFound();

            return Ok(file);
        }


        // POST: api/files
        [HttpPost]
        public async Task<ActionResult<File>> PostFile(File file)
        {
            try
            {
                var newFile = await _fileService.Create(file);
                return Ok(newFile);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/files/{fileId}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile(int id, File file)
        {
            if (id != file.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newFile = await _fileService.Update(file);
                return Ok(newFile);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/files/{fileId}
        [HttpDelete("{id}")]
        public async Task<ActionResult<File>> DeleteFile(int id)
        {
            var file = await _fileService.Delete(id);
            if (file == null) return NotFound();
            else return Ok(file);
        }
    }
}
