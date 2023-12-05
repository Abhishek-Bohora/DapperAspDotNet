using DapperAspNetCore.Dtos;
using DapperAspNetCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperAspNetCore.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try {
                var companies = await _companyRepository.GetCompanies();
                return Ok(companies);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try {
                var company = await _companyRepository.GetCompanyById(id);
                if (company == null)
                {
                    return NotFound();
                }
                return Ok(company);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto company)
        {
            try {
                var createdCompany = await _companyRepository.CreateCompany(company);
                return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDto company)
        {
            try
            {
                var dbCompany = await _companyRepository.GetCompanyById(id);
                if (dbCompany == null)
                {
                    return NotFound();
                }

                await _companyRepository.UpdateCompany(id, company);
                return NoContent();
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var dbCompany = await _companyRepository.GetCompanyById(id);
                if(dbCompany == null)
                {
                    return NotFound();
                }
                await _companyRepository.DeleteCompany(id);
                return NoContent();
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("ByEmployeeId/{id}")]
        public async Task<IActionResult> GetCompanyForEmployee(int id) 
        {
            try
            {
                var company = await _companyRepository.GetCompanyByEmployeeId(id);  
                if(company == null)
                {
                    return NotFound();  
                }
                return Ok(company);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message); 
            }
        }
    }
}
