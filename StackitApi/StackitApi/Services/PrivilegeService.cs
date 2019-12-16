using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class PrivilegeService : IPrivilegeService
    {
        private readonly StackitContext _context;


        public PrivilegeService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Privilege>> GetAll()
        {
            return await _context.Privileges.ToListAsync();
        }


        public async Task<Privilege> GetById(int id)
        {
            return await _context.Privileges.FindAsync(id);
        }


        public async Task<Privilege> Create(Privilege privilege)
        {
            _context.Privileges.Add(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }


        public async Task<Privilege> Update(Privilege privilege)
        {
            if (!PrivilegeExists(privilege.Id))
                throw new AppException("Privilege not found");

            _context.Privileges.Update(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }


        public async Task<Privilege> Delete(int id)
        {
            var privilege = await _context.Privileges.FindAsync(id);

            if (privilege != null)
            {
                _context.Privileges.Remove(privilege);
                await _context.SaveChangesAsync();
            }

            return privilege;
        }


        private bool PrivilegeExists(int id)
        {
            return _context.Privileges.Any(p => p.Id == id);
        }
    }
}
