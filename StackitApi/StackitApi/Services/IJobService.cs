using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();
        Task<Job> GetById(int id);
        Task<IEnumerable<Job>> GetByStackId(int id);
        Task<Job> Create(Job job);
        Task<Job> Update(Job job);
        Task<Job> Delete(int id);
    }
}
