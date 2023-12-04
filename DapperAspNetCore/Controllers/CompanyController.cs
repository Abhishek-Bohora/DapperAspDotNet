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
    }
}
