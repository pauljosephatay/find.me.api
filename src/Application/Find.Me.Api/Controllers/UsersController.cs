using Find.Me.Api.Query.Users;
using Find.Me.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Find.Me.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Gets the Logger
        /// </summary>
        private readonly ILogger<UsersController> Logger;

        /// <summary>
        /// Gets the Mediator
        /// </summary>
        private IMediator Mediator { get; }

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>The list of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSummary>>> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
