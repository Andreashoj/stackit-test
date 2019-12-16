using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IPrivilegeService
    {
        Task<IEnumerable<Privilege>> GetAll();
        Task<Privilege> GetById(int id);
        Task<Privilege> Create(Privilege privilege);
        Task<Privilege> Update(Privilege privilege);
        Task<Privilege> Delete(int id);
    }
}
