using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Find.Me.Api.Repository
{
    public static class MongoDbDependencyInjection
    {
        /// <summary>
        /// The key in connection settings
        /// </summary>
        const string connectionStringKey = "findMe";

        /// <summary>
        /// Adds the MongoDB healthchecks
        /// </summary>
        /// <param name="services">The IServiceCollection to add the MongoClient to.</param>
        /// <param name="configuration"></param>
        /// <returns>The IServiceCollection</returns>
        public static IServiceCollection AddMongoDbHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {


            services
                .AddHealthChecks()
                .AddMongoDb(MongoConnectionFactory.GetMongoClientSettings(configuration.GetConnectionString(connectionStringKey)));
            return services;
        }

        /// <summary>
        /// Adds the MongoClient to the container
        /// </summary>
        /// <param name="services">The IServiceCollection to add the MongoClient to.</param>
        /// <param name="configuration"></param>
        /// <returns>The IServiceCollection</returns>
        public static IServiceCollection AddMongoClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(opts => MongoConnectionFactory.CreateClient(configuration.GetConnectionString(connectionStringKey)));
            return services;
        }
    }
}
