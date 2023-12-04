using Dapper;
using DapperAspNetCore.Context;
using DapperAspNetCore.Models;
using DapperAspNetCore.Repositories.Interfaces;

namespace DapperAspNetCore.Repositories
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;                
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM COMPANIES";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);    
                return companies.ToList();
            }
        }
    }
}
