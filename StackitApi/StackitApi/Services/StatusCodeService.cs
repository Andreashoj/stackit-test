using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class StatusCodeService : IStatusCodeService
    {
        private readonly StackitContext _context;


        public StatusCodeService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<StatusCode>> GetAll()
        {
            return await _context.StatusCodes.ToListAsync();
        }


        public async Task<StatusCode> GetById(int id)
        {
            return await _context.StatusCodes.FindAsync(id);
        }


        public async Task<StatusCode> Create(StatusCode statusCode)
        {
            _context.StatusCodes.Add(statusCode);
            await _context.SaveChangesAsync();
            return statusCode;
        }


        public async Task<StatusCode> Update(StatusCode statusCode)
        {
            if (!StatusCodeExists(statusCode.Id))
                throw new AppException("StatusCode not found");

            _context.StatusCodes.Update(statusCode);
            await _context.SaveChangesAsync();
            return statusCode;
        }


        public async Task<StatusCode> Delete(int id)
        {
            var statusCode = await _context.StatusCodes.FindAsync(id);

            if (statusCode != null)
            {
                _context.StatusCodes.Remove(statusCode);
                await _context.SaveChangesAsync();
            }

            return statusCode;
        }


        private bool StatusCodeExists(int id)
        {
            return _context.StatusCodes.Any(s => s.Id == id);
        }
    }
}
