using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class DefaultPrivilegeService : IDefaultPrivilegeService
    {
        private readonly StackitContext _context;


        public DefaultPrivilegeService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<DefaultPrivilege>> GetAll()
        {
            return await _context.DefaultPrivileges.ToListAsync();
        }


        public async Task<DefaultPrivilege> GetById(int userTypeId, int privilegeId)
        {
            return await _context.DefaultPrivileges
                .Where(dp => dp.UserTypeId == userTypeId)
                .Where(dp => dp.PrivilegeId == privilegeId)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<DefaultPrivilege>> GetByUserTypeId(int id)
        {
            return await _context.DefaultPrivileges
                .Where(dp => dp.UserTypeId == id)
                .ToListAsync();
        }


        public async Task<IEnumerable<DefaultPrivilege>> GetByPrivilegeId(int id)
        {
            return await _context.DefaultPrivileges
                .Where(dp => dp.PrivilegeId == id)
                .ToListAsync();
        }


        public async Task<DefaultPrivilege> Create(DefaultPrivilege defaultPrivilege)
        {
            _context.DefaultPrivileges.Add(defaultPrivilege);
            await _context.SaveChangesAsync();
            return defaultPrivilege;
        }


        public async Task<DefaultPrivilege> Delete(int userTypeId, int privilegeId)
        {
            var defaultPrivilege = await _context.DefaultPrivileges
                .Where(dp => dp.UserTypeId == userTypeId)
                .Where(dp => dp.PrivilegeId == privilegeId)
                .FirstOrDefaultAsync();

            if (defaultPrivilege != null)
            {
                _context.DefaultPrivileges.Remove(defaultPrivilege);
                await _context.SaveChangesAsync();
            }

            return defaultPrivilege;
        }
    }
}
