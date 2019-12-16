using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class FileService : IFileService
    {
        private readonly StackitContext _context;


        public FileService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<File>> GetAll()
        {
            return await _context.Files.ToListAsync();
        }


        public async Task<File> GetById(int id)
        {
            return await _context.Files.FindAsync(id);
        }


        public async Task<File> Create(File file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }


        public async Task<File> Update(File file)
        {
            if (!FileExists(file.Id))
                throw new AppException("File not found");

            _context.Files.Update(file);
            await _context.SaveChangesAsync();
            return file;
        }


        public async Task<File> Delete(int id)
        {
            var file = await _context.Files.FindAsync(id);

            if (file != null)
            {
                _context.Files.Remove(file);
                await _context.SaveChangesAsync();
            }

            return file;
        }


        private bool FileExists(int id)
        {
            return _context.Files.Any(f => f.Id == id);
        }
    }
}
