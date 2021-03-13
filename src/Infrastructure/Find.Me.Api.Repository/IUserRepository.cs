using Find.Me.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Find.Me.Api.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users, optionally filter by role.
        /// </summary>
        /// <param name="role"> user role</param>
        /// <returns> users</returns>
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
