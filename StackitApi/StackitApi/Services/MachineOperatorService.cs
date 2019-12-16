using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class MachineOperatorService : IMachineOperatorService
    {
        private readonly StackitContext _context;


        public MachineOperatorService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<MachineOperator>> GetAll()
        {
            return await _context.MachineOperators.ToListAsync();
        }


        public async Task<MachineOperator> GetById(int userId, int machineId)
        {
            return await _context.MachineOperators
                .Where(mo => mo.UserId == userId)
                .Where(mo => mo.MachineId == machineId)
                .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<MachineOperator>> GetByMachineId(int id)
        {
            return await _context.MachineOperators
                .Where(mo => mo.MachineId == id)
                .ToListAsync();
        }


        public async Task<IEnumerable<MachineOperator>> GetByUserId(int id)
        {
            return await _context.MachineOperators
                .Where(mo => mo.UserId == id)
                .ToListAsync();
        }


        public async Task<MachineOperator> Create(MachineOperator machineOperator)
        {
            _context.MachineOperators.Add(machineOperator);
            await _context.SaveChangesAsync();
            return machineOperator;
        }


        public async Task<MachineOperator> Delete(int userId, int machineId)
        {
            var machineOperator = await _context.MachineOperators
                .Where(mo => mo.UserId == userId)
                .Where(mo => mo.MachineId == machineId)
                .FirstOrDefaultAsync();

            if (machineOperator != null)
            {
                _context.MachineOperators.Remove(machineOperator);
                await _context.SaveChangesAsync();
            }

            return machineOperator;
        }
    }
}
