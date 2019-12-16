using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly StackitContext _context;


        public CompanyService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }


        public async Task<Company> GetById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }


        public async Task<IEnumerable<Company>> GetByCityId(int id)
        {
            return await _context.Companies
                .Where(c => c.CityId == id)
                .ToListAsync();
        }


        public async Task<Company> Create(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }


        public async Task<Company> Update(Company company)
        {
            if (!CompanyExists(company.Id))
                throw new AppException("Company not found");

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }


        public async Task<Company> Delete(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }

            return company;
        }


        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(c => c.Id == id);
        }
    }
}
