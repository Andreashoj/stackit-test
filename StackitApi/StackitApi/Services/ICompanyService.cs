using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<IEnumerable<Company>> GetByCityId(int id);
        Task<Company> Create(Company company);
        Task<Company> Update(Company company);
        Task<Company> Delete(int id);
    }
}
