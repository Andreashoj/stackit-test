using System.Collections.Generic;
using System.Threading.Tasks;
using StackitApi.Models;

namespace StackitApi.Services
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetAll();
        Task<File> GetById(int id);
        Task<File> Create(File file);
        Task<File> Update(File file);
        Task<File> Delete(int id);
    }
}
