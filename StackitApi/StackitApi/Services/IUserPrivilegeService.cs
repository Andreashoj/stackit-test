using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IUserPrivilegeService
    {
        Task<IEnumerable<UserPrivilege>> GetAll();
        Task<UserPrivilege> GetById(int userId, int privilegeId);
        Task<IEnumerable<UserPrivilege>> GetByUserId(int id);
        Task<IEnumerable<UserPrivilege>> GetByPrivilegeId(int id);
        Task<UserPrivilege> Create(UserPrivilege userPrivilege);
        Task<UserPrivilege> Delete(int userId, int privilegeId);
    }
}
