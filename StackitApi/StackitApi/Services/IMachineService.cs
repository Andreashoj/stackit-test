using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IMachineService
    {
        Task<IEnumerable<Machine>> GetAll();
        Task<Machine> GetById(int id);
        Task<IEnumerable<Machine>> GetByCompanyId(int id);
        Task<Machine> Create(Machine company);
        Task<Machine> Update(Machine company);
        Task<Machine> Delete(int id);
    }
}
