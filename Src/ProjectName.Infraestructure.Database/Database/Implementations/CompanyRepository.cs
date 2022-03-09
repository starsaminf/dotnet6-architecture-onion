using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectName.Domain.Abstractions;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database.Entities;

namespace ProjectName.Infrastructure.Database.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IMongoCollection<DbCompany> _companiesCollection;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CompanyRepository(IMongoClient mongoClient, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _companiesCollection = mongoClient.GetDatabase(_configuration["MongoDB:Name"]).GetCollection<DbCompany>("companies");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            IEnumerable<DbCompany> companies = _companiesCollection
                .FindAsync(company => company.IsDeleted == false)
                .Result
                .ToList();

            return _mapper.Map<IEnumerable<Company>>(companies);
        }

        public async Task<Company> CreateCompanyAsync(Company company)
        {
            DbCompany newCompany = _mapper.Map<Company, DbCompany>(company);
            newCompany.IsDeleted = false;
            await _companiesCollection.InsertOneAsync(newCompany);
            return _mapper.Map<DbCompany, Company>(newCompany);
        }
    }
}