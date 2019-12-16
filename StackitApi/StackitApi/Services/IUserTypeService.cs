using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAll();
        Task<UserType> GetById(int id);
        Task<UserType> Create(UserType userType);
        Task<UserType> Update(UserType userType);
        Task<UserType> Delete(int id);
    }
}
