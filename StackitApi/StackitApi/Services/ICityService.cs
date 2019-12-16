using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetById(int id);
        Task<City> Create(City city);
        Task<City> Update(City city);
        Task<City> Delete(int id);
    }
}
