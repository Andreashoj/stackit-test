using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class MachineService : IMachineService
    {
        private readonly StackitContext _context;


        public MachineService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Machine>> GetAll()
        {
            return await _context.Machines.ToListAsync();
        }


        public async Task<Machine> GetById(int id)
        {
            return await _context.Machines.FindAsync(id);
        }


        public async Task<IEnumerable<Machine>> GetByCompanyId(int id)
        {
            return await _context.Machines
                .Where(m => m.CompanyId == id)
                .ToListAsync();
        }


        public async Task<Machine> Create(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
            return machine;
        }


        public async Task<Machine> Update(Machine machine)
        {
            if (!MachineExists(machine.Id))
                throw new AppException("Machine not found");

            _context.Machines.Update(machine);
            await _context.SaveChangesAsync();
            return machine;
        }


        public async Task<Machine> Delete(int id)
        {
            var machine = await _context.Machines.FindAsync(id);

            if (machine != null)
            {
                _context.Machines.Remove(machine);
                await _context.SaveChangesAsync();
            }

            return machine;
        }


        private bool MachineExists(int id)
        {
            return _context.Machines.Any(m => m.Id == id);
        }
    }
}
