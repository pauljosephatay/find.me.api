using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Find.Me.Api.Repository
{
    /// <summary>
    /// Mongo Connection Factory
    /// </summary>
    public static class MongoConnectionFactory
    {
        /// <summary>
        /// Gets the mongo client instance. use to maintain a shared instance.
        /// </summary>
        private static IMongoClient MongoClient { get; set; }

        /// <summary>
        /// Gets or sets the mongo client settings.
        /// </summary>
        private static MongoClientSettings MongoClientSettings { get; set; }

        /// <summary>
        /// Retrieves the mongo DB client settings based on the connection string.
        /// </summary>
        /// <param name="connectionString"> connection string</param>
        /// <returns></returns>
        public static MongoClientSettings GetMongoClientSettings(string connectionString)
        {
            if (MongoClientSettings is null)
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                MongoClientSettings = settings;
            }

            return MongoClientSettings;
        }

        /// <summary>
        /// Create mongo DB client.
        /// </summary>
        /// <param name="connectionString"> connection string</param>
        /// <returns></returns>
        public static IMongoClient CreateClient(string connectionString)
        {
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", pack, t => true);            
            return MongoClient ??= new MongoClient(GetMongoClientSettings(connectionString));
        }
    }
}
