using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class JobService : IJobService
    {
        private readonly StackitContext _context;


        public JobService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }


        public async Task<Job> GetById(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }


        public async Task<IEnumerable<Job>> GetByStackId(int id)
        {
            return await _context.Jobs
                .Where(s => s.StackId == id)
                .ToListAsync();
        }


        public async Task<Job> Create(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }


        public async Task<Job> Update(Job job)
        {
            if (!JobExists(job.Id))
                throw new AppException("Job not found");

            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }


        public async Task<Job> Delete(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }

            return job;
        }


        private bool JobExists(int id)
        {
            return _context.Jobs.Any(m => m.Id == id);
        }
    }
}
