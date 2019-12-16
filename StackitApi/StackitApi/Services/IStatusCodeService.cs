using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IStatusCodeService
    {
        Task<IEnumerable<StatusCode>> GetAll();
        Task<StatusCode> GetById(int id);
        Task<StatusCode> Create(StatusCode statusCode);
        Task<StatusCode> Update(StatusCode statusCode);
        Task<StatusCode> Delete(int id);
    }
}
