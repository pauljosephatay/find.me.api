using AutoMapper;
using Find.Me.Api.Repository.Entities;
using Find.Me.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Find.Me.Api.Repository
{
    // <summary>
    /// User repo
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Gets the users collection
        /// </summary>
        private IMongoCollection<UserEntity> Users { get; }

        /// <summary>
        /// Gets the utility mapper
        /// </summary>        
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="mongoClient">The mongo client</param>        
        public UserRepository(IMongoClient mongoClient, IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            var db = mongoClient?.GetDatabase(MongoConstants.DatabaseName) ?? throw new ArgumentNullException(nameof(mongoClient));
            Users = db.GetCollection<UserEntity>(MongoConstants.UsersCollectionName);
        }

        /// <summary>
        /// Get all users
        /// </summary>        
        /// <returns>The users mapped as domain users</returns>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await Users.FindAsync(t => true);
            return Mapper.Map<IEnumerable<User>>(users.ToList());
        }
    }
}
