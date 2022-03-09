using ProjectName.Domain.Entities;

namespace ProjectName.Domain.Abstractions
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompaniesAsync();
        public Task<Company> CreateCompanyAsync(Company company);
    }
}