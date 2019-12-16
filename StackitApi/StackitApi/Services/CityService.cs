using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackitApi.Models;

namespace StackitApi.Services
{
    public class CityService : ICityService
    {
        private readonly StackitContext _context;


        public CityService(StackitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }


        public async Task<City> GetById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }


        public async Task<City> Create(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }


        public async Task<City> Update(City city)
        {
            if (!CityExists(city.Id))
                throw new AppException("City not found");

            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }


        public async Task<City> Delete(int id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }

            return city;
        }


        private bool CityExists(int id)
        {
            return _context.Cities.Any(c => c.Id == id);
        }
    }
}
