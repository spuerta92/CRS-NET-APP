using CRS_DAO.SqlServerClient;
using CRS_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_Automation
{
    public class SmokeTests
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
    }
}
