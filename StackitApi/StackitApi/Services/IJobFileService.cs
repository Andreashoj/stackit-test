using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IJobFileService
    {
        Task<IEnumerable<JobFile>> GetAll();
        Task<JobFile> GetById(int jobId, int fileId);
        Task<IEnumerable<JobFile>> GetByJobId(int id);
        Task<IEnumerable<JobFile>> GetByFileId(int id);
        Task<JobFile> Create(JobFile jobFile);
        Task<JobFile> Delete(int jobId, int fileId);
    }
}
