using Microsoft.Extensions.DependencyInjection;


namespace ProjectName.WebApi.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebApiControllers(this IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            return services;
        }
    }
}