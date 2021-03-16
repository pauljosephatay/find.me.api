using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Find.Me.Api.Repository.Entities;
using Find.Me.Api.Repository.Mapping;
using Find.Me.Domain;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Find.Me.Api.Repository.Tests
{
    public class UserRepositoryTests
    {
        private Mock<IMongoClient> _mockClient;
        private Mock<IMongoDatabase> _mockDB;
        private IMapper _mapper;
        private Mock<IMongoCollection<UserEntity>> _mockCollection;

        public UserRepositoryTests()
        {
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
            _mockCollection = new Mock<IMongoCollection<UserEntity>>();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserEntityToDomainProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void RepositoryConsructorSuccess()
        {
            _mockClient.Setup(c => c.GetDatabase(MongoConstants.DatabaseName, null)).Returns(_mockDB.Object);
            var repo = new UserRepository(_mockClient.Object, _mapper);
            Assert.NotNull(repo);
        }

        [Fact]
        public async Task GetAllUsersAsyncShouldReturnsList()
        {
            // Setup
            var addressVO = new AddressValueObject { 
                Name = "The Address",
                Lat = 0,
                Lng = 0,
                WithPets = true,
                PetPhoto = ""
            };

            var user = new UserEntity
            {
                Id = "123",
                Name = "John Smith",                
                Address = addressVO
            };

            var _list = new List<UserEntity>
            {
                user
            };

            //Mock MoveNextAsync
            Mock<IAsyncCursor<UserEntity>> mockCursor = new Mock<IAsyncCursor<UserEntity>>();
            mockCursor.Setup(_ => _.Current).Returns(_list);
            mockCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);
            mockCursor
            .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(true))
            .Returns(Task.FromResult(false));



            //Mock FindSync
            _mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<UserEntity>>(),
            It.IsAny<FindOptions<UserEntity, UserEntity>>(),
             It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);
                        
            _mockDB.Setup(c => c.GetCollection<UserEntity>(MongoConstants.UsersCollectionName, null)).Returns(_mockCollection.Object);

            _mockClient.Setup(c => c.GetDatabase(MongoConstants.DatabaseName, null)).Returns(_mockDB.Object);
            var repo = new UserRepository(_mockClient.Object, _mapper);

            var expected = new List<User> { new User("123", "John Smith", new Address(0, 0, "The Address", true, "")) };

            // Act
            var actual = await repo.GetAllUsersAsync();

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
