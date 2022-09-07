namespace BwlogApi.UnitTests.Systems.Controllers;

using System.Threading.Tasks;
using BwlogApi.API.Controllers;
using BwlogApi.API.Models;
using BwlogApi.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
public class TestUsersController
{

    [Fact]
    public Task GetUserOnSuccessReturnUsers()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UsersController>>();
        var mockUserRepository = new Mock<IUserRepository>();
        var controller = new UsersController(mockLogger.Object, mockUserRepository.Object);
        // Act
        var result = controller.GetUsers();
        // Assert
        Assert.IsType<List<User>>(result);
        return Task.CompletedTask;
    }
    [Fact]
    public Task GetUserOnSuccessReturnUserById()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<UsersController>>();
        var mockUserRepository = new Mock<IUserRepository>();
        var controller = new UsersController(mockLogger.Object, mockUserRepository.Object);
        // Act
        var result = controller.GetUserById(Guid.NewGuid());
        // Assert
        Assert.IsType<OkObjectResult>(result);
        return Task.CompletedTask;
    }
}
