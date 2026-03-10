using Financio.Domain.Settings;
using Financio.Infrastructure.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Financio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration
                .GetSection("MongoDb")
                .Get<MongoSettings>();


            if (mongoDbSettings == null)
                throw new InvalidOperationException("MongoDB settings are not configured properly.");

            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);

            services.AddSingleton(mongoDatabase);
            services.AddScoped<IBaseRepository, BaseRepository>();
            return services;
        }
    }
}
