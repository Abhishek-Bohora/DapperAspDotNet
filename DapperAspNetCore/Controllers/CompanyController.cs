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
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }    
        }

        [HttpGet("{id}", Name = "ComanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try {
                var company = await _companyRepository.GetCompanyById(id);
                if(company == null)
                {
                    return NotFound();
                }
                return Ok(company);
            }catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
