﻿using DapperAspNetCore.Models;

namespace DapperAspNetCore.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompanyById(int id);
    }
}
