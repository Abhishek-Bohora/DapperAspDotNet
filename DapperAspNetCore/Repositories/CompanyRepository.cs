using Dapper;
using DapperAspNetCore.Context;
using DapperAspNetCore.Dtos;
using DapperAspNetCore.Models;
using DapperAspNetCore.Repositories.Interfaces;
using System.Data;

namespace DapperAspNetCore.Repositories
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;                
        }

        public async Task<Company> CreateCompany(CreateCompanyDto company)
        {
            var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", company.Name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdCompany = new Company
                {
                    Id = id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country,
                };

                return createdCompany;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            //if we want to use a different name than that in a table name than we have to map it using as
            //var query = "SELECT Id, Name as CompanyName, address, country FROM COMPANIES";

            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);    
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id=@Id";
            using (var connection = _context.CreateConnection()) 
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new {id});
                return company;
            } 
        }
    }
}
