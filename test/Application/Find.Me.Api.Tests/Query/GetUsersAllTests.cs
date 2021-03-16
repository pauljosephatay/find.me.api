using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Find.Me.Api.Mapping;
using Find.Me.Api.Query.Users;
using Find.Me.Api.Repository;
using Find.Me.Api.ViewModels;
using Find.Me.Domain;
using Moq;
using Xunit;

namespace Find.Me.Api.Tests
{
    public class GetUsersAllTests
    {
        private Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        public GetUsersAllTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAllUsersQueryShouldReturnList()
        {
            // Prepare
            var list = new List<User> { new User("123", "John Smith", new Address(0, 0, "The Address", true, "")) };
            _mockRepo.Setup(c => c.GetAllUsersAsync()).ReturnsAsync(list.AsEnumerable());
            
            var resultToMap = new List<User> { new User("123", "John Smith", new Address(0, 0, "The Address", true, "")) };
            var expected = _mapper.Map<IEnumerable<UserSummary>>(resultToMap);

            var handler = new GetAllUsersQueryHandler(_mockRepo.Object, _mapper);

            var query = new GetAllUsersQuery();
            // Act
            var actual = await handler.Handle(query, default);

            // Assert
            Assert.Collection(actual,
                item =>
                {
                    Assert.Equal("123", item.Id);
                    Assert.Equal("John Smith", item.Name);
                    Assert.Equal("The Address", item.Address.Name);
                }
            );

        }
    }
}
