
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Conventions;
using ProjectName.Domain.Abstractions;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database.Implementations;
using ProjectName.Infrastructure.Database.Entities;

namespace ProjectName.Infrastructure.Database.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            return services;
        }

        public static IServiceCollection AddMongoClient(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var conventionPack = new ConventionPack();
                conventionPack.Add(new CamelCaseElementNameConvention());

                ConventionRegistry.Register("CamelCase", conventionPack, type => true);

                BsonClassMap.RegisterClassMap<Company>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdMember(c => c.Id)
                        .SetIdGenerator(new GuidGenerator())
                        .SetSerializer(new GuidSerializer(BsonType.ObjectId));
                    cm.SetIgnoreExtraElements(true);
                });


                var uri = s.GetRequiredService<IConfiguration>().GetConnectionString("mongoUri");
                return new MongoClient(uri);
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
