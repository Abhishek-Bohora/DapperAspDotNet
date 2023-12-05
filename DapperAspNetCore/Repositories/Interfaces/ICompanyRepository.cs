using DapperAspNetCore.Dtos;
using DapperAspNetCore.Models;

namespace DapperAspNetCore.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompanyById(int id);
        public Task<Company> CreateCompany(CreateCompanyDto company);
        public Task UpdateCompany(int id, UpdateCompanyDto company);
        public Task DeleteCompany(int id);
    }
}
