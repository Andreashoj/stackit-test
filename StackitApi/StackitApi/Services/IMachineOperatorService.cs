using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IMachineOperatorService
    {
        Task<IEnumerable<MachineOperator>> GetAll();
        Task<MachineOperator> GetById(int userId, int machineId);
        Task<IEnumerable<MachineOperator>> GetByMachineId(int id);
        Task<IEnumerable<MachineOperator>> GetByUserId(int id);
        Task<MachineOperator> Create(MachineOperator machineOperator);
        Task<MachineOperator> Delete(int userId, int machineId);
    }
}
