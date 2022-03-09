using ProjectName.Domain.Abstractions;
using ProjectName.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectName.Services.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICompanyService, CompanyService>();
            return services;
        }
    }
}