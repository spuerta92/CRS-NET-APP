using System.Text;
using CRS_DAO;
using CRS_DAO.EntityFramework;
using CRS_DAO.SqlServerClient;
using CRS_MODELS;
using MongoDB.Driver;

namespace CRS_Automation.TDD
{
    public class UserApiTests
    {
        private Api api;
        private ICrsRepository repository;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            api = new Api();
            repository = new SqlServerCrsRepository();
        }

        [SetUp]
        public void Setup()
        {
            // nothing for now
        }

        [TearDown]
        public void TearDown()
        {
            // nothing for now
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            // nothing for now
        }

        // Arrage, Act, Assert
        [Test]
        public void Users_AddUser_ExpectedNewUser()
        {
            var guid = Guid.NewGuid();
            var user = new Users()
            {
                UserName = @$"Test User {guid}",
                Password = guid.ToString(),
                RoleId = 3
            };
            var response = api.AddUser(user);
            var dbUser = repository.GetUser(user.UserName, user.Password, user.RoleId);
            Assert.That(response?.UUID == dbUser?.UUID, "user UUID do not match up, user was not properly added");
        }

        [Test]
        public void Users_GetAllUsers_ExpectedListOfUsers()
        {
            var response = api.GetAllUsers3();
            var dbUserList = repository.GetUsers().ToList();
            Assert.That(response?.Count == dbUserList.Count, "User list counts don't match");
        }

        [Test]
        public void Users_GetUserByUserId_ExpectedExistingUser()
        {
            int userId = 1;
            var response = api.GetUserById(userId);
            var dbUser = repository.GetUser(userId);
            Assert.That(response.UserName == dbUser.UserName);
            Assert.That(response.RoleId == dbUser.RoleId);
        }

        [Test]
        public void Users_GetUserByUserCredentials_ExpectedExistingUser()
        {
            int userId = 1;
            var response = api.GetUser("admin", "admin", 1);
            var dbUser = repository.GetUser(userId);
            Assert.That(response.UserId == dbUser.UserId, "UserIds do not match");
        }

        [Test]
        public void Users_UpdateUser_ExpectedUpdatedUser()
        {
            var existingUser = repository.GetLastUser();
            if (existingUser == null)
            {
                throw new Exception("No users available");
            }
            var updatedUser = new Users()
            {
                UserName = existingUser.UserName,
                Password = existingUser.Password,
                RoleId = 2
            };
            var response = api.UpdateUser(existingUser.UserId, updatedUser);
            var dbUser = repository.GetUser(existingUser.UserId);
            Assert.That(response?.RoleId == dbUser?.RoleId, "User roleId do not match, user was not updated");
        }

        [Test]
        public void Users_DeleteUser_ExpectedNull()
        {
            var existingUser = repository.GetLastUser();
            if (existingUser == null)
            {
                throw new Exception("No users available");
            }
            api.DeleteUser(existingUser.UserId);
            var dbUser = repository.GetUser(existingUser.UserId);
            Assert.Null(dbUser, "User exists, user was not deleted");
        }
    }
}