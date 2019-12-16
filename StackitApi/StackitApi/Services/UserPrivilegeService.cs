using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class UserPrivilegeService : IUserPrivilegeService
    {
        private readonly StackitContext _context;


        public UserPrivilegeService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<UserPrivilege>> GetAll()
        {
            return await _context.UserPrivileges.ToListAsync();
        }


        public async Task<UserPrivilege> GetById(int userId, int privilegeId)
        {
            return await _context.UserPrivileges
                .Where(up => up.UserId == userId)
                .Where(up => up.PrivilegeId == privilegeId)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<UserPrivilege>> GetByUserId(int id)
        {
            return await _context.UserPrivileges
                .Where(up => up.UserId == id)
                .ToListAsync();
        }


        public async Task<IEnumerable<UserPrivilege>> GetByPrivilegeId(int id)
        {
            return await _context.UserPrivileges
                .Where(up => up.PrivilegeId == id)
                .ToListAsync();
        }


        public async Task<UserPrivilege> Create(UserPrivilege userPrivilege)
        {
            _context.UserPrivileges.Add(userPrivilege);
            await _context.SaveChangesAsync();
            return userPrivilege;
        }


        public async Task<UserPrivilege> Delete(int userId, int privilegeId)
        {
            var userPrivilege = await _context.UserPrivileges
                .Where(up => up.UserId == userId)
                .Where(up => up.PrivilegeId == privilegeId)
                .FirstOrDefaultAsync();

            if (userPrivilege != null)
            {
                _context.UserPrivileges.Remove(userPrivilege);
                await _context.SaveChangesAsync();
            }

            return userPrivilege;
        }
    }
}
