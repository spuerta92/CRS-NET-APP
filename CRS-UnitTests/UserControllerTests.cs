using CRS_BUSINESS;
using CRS_DAO;
using CRS_DTOS.UserDtos;
using CRS_MODELS;
using CRS_WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CRS_UnitTests
{
    public class UserControllerTests
    {
        private readonly Mock<ICrsRepository> repositoryStub = new();
        private readonly Mock<ILogger<UserController>> loggerStub = new();
        private readonly Mock<ILogger<UserBLL>> loggerStubBLL = new();
        private readonly Random rand = new Random();
        private readonly UserController controller;

        public UserControllerTests()
        {
            controller = new UserController(loggerStub.Object, loggerStubBLL.Object, repositoryStub.Object);
        }

        [Fact]
        public void GetUsers_UsersExist_ReturnsExpectedUserList()
        {
            // Arrange
            var expectedUsers = new List<Users> { CreateUser(), CreateUser(), CreateUser() };
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(expectedUsers);

            // Act
            var actionResult = controller.GetUsers();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.Should().BeEquivalentTo(expectedUsers, options => options.ComparingByMembers<Users>());
        }

        [Fact]
        public void GetUserById_UsersExist_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = CreateUser();
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<int>())).Returns(expectedUser);

            // Act
            var actionResult = controller.GetUser(rand.Next(1,999));

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.Should().BeEquivalentTo(expectedUser, options => options.ComparingByMembers<Users>());
        }

        [Fact]
        public void GetUserByCredentials_UsersExist_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = CreateUser();
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(expectedUser);

            // Act
            var actionResult = controller.GetUser("test", "test", rand.Next(1,3));

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var updatedUser = result?.Value;
            result.Should().BeEquivalentTo(updatedUser, options => options.ComparingByMembers<Users>());
        }

        [Fact]
        public void AddUser_InsertNewUser_ReturnsCreatedUser()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var userToAdd = new AddUserDto()
            {
                UserName = $"Test user {guid}",
                Password = $"Test password {guid}",
                RoleId = rand.Next(1, 3)
            };

            // Act
            var actionResult = controller.AddUser(userToAdd);

            // Assert
            var result = actionResult.Result as CreatedAtActionResult;
            var value = result?.Value as UserDto;
            result.Should().BeEquivalentTo(value, options => options.ComparingByMembers<Users>().ExcludingMissingMembers());
        }

        [Fact]
        public void UpdateUser_UpdatesAnExistingUser_ReturnsUpdatedUser()
        {
            // Arrange
            var user = CreateUser();
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<int>())).Returns(user);

            var guid = Guid.NewGuid();
            var userToUpdate = new UpdateUserDto()
            {
                UserName = $"Test user {guid}",
                Password = $"Test password {guid}",
                RoleId = rand.Next(1, 3)
            };

            // Act
            var actionResult = controller.UpdateUser(user.UserId, userToUpdate);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.Should().BeEquivalentTo(userToUpdate, options => options.ComparingByMembers<Users>().ExcludingMissingMembers());
        }

        [Fact]
        public void DeleteUser_DeletesAnExistingUser_ReturnsNoContent()
        {
            // Arrange
            var user = CreateUser();
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<int>())).Returns(user);

            // Act
            var actionResult = controller.DeleteUser(user.UserId);

            // Assert
            actionResult.Should().BeOfType<NoContentResult>();
        }


        private Users CreateUser()
        {
            var guid = Guid.NewGuid();
            return new Users()
            {
                UserId = rand.Next(1, 999),
                UserName = $"Test User {guid}",
                Password = $"Test Password {guid}",
                RoleId = rand.Next(1, 3),
                UUID = guid.ToString(),
                CreateDateTime = DateTime.Now
            };
        }
    }
}