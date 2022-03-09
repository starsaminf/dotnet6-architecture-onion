using ProjectName.Domain.Entities;

namespace ProjectName.Domain.Abstractions
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetCompaniesAsync();
        public Task<Company> CreateCompanyAsync(Company company);
    }
}