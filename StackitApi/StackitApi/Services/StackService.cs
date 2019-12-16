using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class StackService : IStackService
    {
        private readonly StackitContext _context;


        public StackService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Stack>> GetAll()
        {
            return await _context.Stacks.ToListAsync();
        }


        public async Task<Stack> GetById(int id)
        {
            return await _context.Stacks.FindAsync(id);
        }


        public async Task<IEnumerable<Stack>> GetByMachineId(int id)
        {
            return await _context.Stacks
                .Where(s => s.MachineId == id)
                .ToListAsync();
        }


        public async Task<Stack> Create(Stack stack)
        {
            _context.Stacks.Add(stack);
            await _context.SaveChangesAsync();
            return stack;
        }


        public async Task<Stack> Update(Stack stack)
        {
            if (!StackExists(stack.Id))
                throw new AppException("Stack not found");

            _context.Stacks.Update(stack);
            await _context.SaveChangesAsync();
            return stack;
        }


        public async Task<Stack> Delete(int id)
        {
            var stack = await _context.Stacks.FindAsync(id);

            if (stack != null)
            {
                _context.Stacks.Remove(stack);
                await _context.SaveChangesAsync();
            }

            return stack;
        }


        private bool StackExists(int id)
        {
            return _context.Stacks.Any(m => m.Id == id);
        }
    }
}
