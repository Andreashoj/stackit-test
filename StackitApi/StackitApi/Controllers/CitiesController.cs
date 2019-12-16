using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackitApi.Models;
using StackitApi.Services;

namespace StackitApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;


        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }


        // GET: api/cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _cityService.GetAll();
            return Ok(cities);
        }


        // GET: api/cities/{cityId}
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityService.GetById(id);

            if (city == null)
                return NotFound();

            return Ok(city);
        }


        // POST: api/cities
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            try
            {
                var newCity = await _cityService.Create(city);
                return Ok(newCity);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/cities/{cityId}
        //[Authorize(Roles = "S_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newCity = await _cityService.Update(city);
                return Ok(newCity);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/cities/{cityId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _cityService.Delete(id);
            if (city == null) return NotFound();
            else return Ok(city);
        }
    }
}
