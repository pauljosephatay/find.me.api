using AutoMapper;
using Find.Me.Api.Repository;
using Find.Me.Api.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Find.Me.Api.Query.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserSummary>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserSummary>>
    {
        /// <summary>
        /// Gets the repository
        /// </summary>
        private IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets the mapper
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GetAllUsersQueryHandler"/>
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>Handles a request</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The users mapped as user summary</returns>
        public async Task<IEnumerable<UserSummary>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await UserRepository.GetAllUsersAsync();

            return Mapper.Map<IEnumerable<UserSummary>>(result);
        }
    }
}
