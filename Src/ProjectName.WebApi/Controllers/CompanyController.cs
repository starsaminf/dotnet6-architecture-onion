using ProjectName.Domain.Abstractions;
using ProjectName.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProjectName.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _companyService.GetCompaniesAsync();
        }

        [HttpPost]
        public async Task<Company> CreateCompany([FromBody] Company company)
        {
            return await _companyService.CreateCompanyAsync(company);
        }
    }
}
