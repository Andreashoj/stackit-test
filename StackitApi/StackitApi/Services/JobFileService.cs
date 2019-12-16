using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class JobFileService : IJobFileService
    {
        private readonly StackitContext _context;


        public JobFileService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<JobFile>> GetAll()
        {
            return await _context.JobFiles.ToListAsync();
        }


        public async Task<JobFile> GetById(int jobId, int fileId)
        {
            return await _context.JobFiles
                .Where(jf => jf.JobId == jobId)
                .Where(jf => jf.FileId == fileId)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<JobFile>> GetByJobId(int id)
        {
            return await _context.JobFiles
                .Where(jf => jf.JobId == id)
                .ToListAsync();
        }


        public async Task<IEnumerable<JobFile>> GetByFileId(int id)
        {
            return await _context.JobFiles
                .Where(jf => jf.FileId == id)
                .ToListAsync();
        }


        public async Task<JobFile> Create(JobFile jobFile)
        {
            _context.JobFiles.Add(jobFile);
            await _context.SaveChangesAsync();
            return jobFile;
        }


        public async Task<JobFile> Delete(int jobId, int fileId)
        {
            var jobFile = await _context.JobFiles
                .Where(jf => jf.JobId == jobId)
                .Where(jf => jf.FileId == fileId)
                .FirstOrDefaultAsync();

            if (jobFile != null)
            {
                _context.JobFiles.Remove(jobFile);
                await _context.SaveChangesAsync();
            }

            return jobFile;
        }
    }
}
