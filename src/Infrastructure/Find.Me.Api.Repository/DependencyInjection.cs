using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Find.Me.Api.Repository
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add infrastructure services to the container
        /// </summary>
        /// <param name="services">The IServiceCollection add services to.</param>
        /// <param name="configuration">The IConfiguration to get settings from</param>
        /// <returns>The IServiceCollection</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbHealthChecks(configuration);
            services.AddMongoClient(configuration);

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
