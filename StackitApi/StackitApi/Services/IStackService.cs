using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IStackService
    {
        Task<IEnumerable<Stack>> GetAll();
        Task<Stack> GetById(int id);
        Task<IEnumerable<Stack>> GetByMachineId(int id);
        Task<Stack> Create(Stack stack);
        Task<Stack> Update(Stack stack);
        Task<Stack> Delete(int id);
    }
}
