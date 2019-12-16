using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IDefaultPrivilegeService
    {
        Task<IEnumerable<DefaultPrivilege>> GetAll();
        Task<DefaultPrivilege> GetById(int userTypeId, int privilegeId);
        Task<IEnumerable<DefaultPrivilege>> GetByUserTypeId(int id);
        Task<IEnumerable<DefaultPrivilege>> GetByPrivilegeId(int id);
        Task<DefaultPrivilege> Create(DefaultPrivilege defaultPrivilege);
        Task<DefaultPrivilege> Delete(int userTypeId, int privilegeId);
    }
}
