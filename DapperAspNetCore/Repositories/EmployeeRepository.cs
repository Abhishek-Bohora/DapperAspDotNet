using DapperAspNetCore.Context;
using DapperAspNetCore.Repositories.Interfaces;

namespace DapperAspNetCore.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
                _context = context;
        }
    }
}
