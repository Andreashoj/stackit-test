using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly StackitContext _context;


        public UserTypeService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<UserType>> GetAll()
        {
            return await _context.UserTypes.ToListAsync();
        }


        public async Task<UserType> GetById(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }


        public async Task<UserType> Create(UserType userType)
        {
            _context.UserTypes.Add(userType);
            await _context.SaveChangesAsync();
            return userType;
        }


        public async Task<UserType> Update(UserType userType)
        {
            if (!UserTypeExists(userType.Id))
                throw new AppException("UserType not found");

            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
            return userType;
        }


        public async Task<UserType> Delete(int id)
        {
            var userType = await _context.UserTypes.FindAsync(id);

            if (userType != null)
            {
                _context.UserTypes.Remove(userType);
                await _context.SaveChangesAsync();
            }

            return userType;
        }


        private bool UserTypeExists(int id)
        {
            return _context.UserTypes.Any(s => s.Id == id);
        }
    }
}
