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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;


        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        // GET: api/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _companyService.GetAll();
            return Ok(companies);
        }


        // GET: api/companies/{companyId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }


        // GET: api/companies/cities/{cityId}
        [HttpGet("cities/{id}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesForCity(int id)
        {
            var companies = await _companyService.GetByCityId(id);
            return Ok(companies);
        }


        // POST: api/companies
        //[Authorize(Roles = "S_Admin")]
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            try
            {
                var newCompany = await _companyService.Create(company);
                return Ok(newCompany);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // PUT: api/companies/{companyId}
        //[Authorize(Roles = "S_Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
                return BadRequest(new { message = "Id in body doesn't match Id in URI" });

            try
            {
                var newCompany = await _companyService.Update(company);
                return Ok(newCompany);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // DELETE: api/companies/{companyId}
        //[Authorize(Roles = "S_Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var company = await _companyService.Delete(id);
            if (company == null) return NotFound();
            else return Ok(company);
        }
    }
}
