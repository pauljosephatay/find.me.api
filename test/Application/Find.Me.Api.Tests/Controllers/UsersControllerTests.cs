using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Find.Me.Api.Controllers;
using Find.Me.Api.Query.Users;
using Find.Me.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Find.Me.Api.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task GetUsersReturnsOkResultWithUsers()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetAllUsersQuery>(), default))
                .ReturnsAsync(GetUsers());
            var controller = new UsersController(mockMediator.Object, new NullLogger<UsersController>());

            // Act
            var actionResult = await controller.Get();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var list = Assert.IsAssignableFrom<IEnumerable<UserSummary>>(result.Value);
            Assert.Single(list);
        }

        private IEnumerable<UserSummary> GetUsers() => new List<UserSummary> { 
            new UserSummary
            {
                Id = "123", 
                Name = "John Smith",
                Address = new AddressVM {
                    Lat = 0, Lng = 0, Name = "The Address", WithPets = true, PetPhoto = ""
                }
            }
        };
    }
}
