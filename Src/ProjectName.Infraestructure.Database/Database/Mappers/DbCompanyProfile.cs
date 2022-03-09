using AutoMapper;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database.Entities;

namespace ProjectName.Infrastructure.Database.Mappers
{
    public class DbCompanyProfile : Profile
    {
        public DbCompanyProfile()
        {
            CreateMap<Company, DbCompany>();
            CreateMap<DbCompany, Company>();
        }
    }
}