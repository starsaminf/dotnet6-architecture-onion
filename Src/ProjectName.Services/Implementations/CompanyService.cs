using ProjectName.Domain.Entities;
using ProjectName.Domain.Abstractions;

namespace ProjectName.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _companyRepository.GetCompaniesAsync();
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            return await _companyRepository.CreateCompanyAsync(company);
        }
    }
}