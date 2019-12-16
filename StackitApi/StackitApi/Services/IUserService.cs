using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetByUserTypeId(int id);
        Task<IEnumerable<User>> GetByCompanyId(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
    }
}
