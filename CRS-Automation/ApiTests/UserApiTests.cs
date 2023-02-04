using CRS_DAO;
using CRS_DAO.EntityFramework;
using CRS_DAO.SqlServerClient;

namespace CRS_Automation.TDD
{
    public class Tests
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

        // Arrage, Act, Assert
        [Test]
        public void Users_AddUser_ExpectedNewUser()
        {
            Assert.Pass();
        }

        [Test]
        public void Users_GetAllUsers_ExpectedListOfUsers()
        {
            var response = api.GetAllUsers();
            var dbUserList = repository.GetUsers().ToList();
            Assert.That(response.Count == dbUserList.Count, "User list counts don't match");
        }

        [Test]
        public void Users_GetUserByUserId_ExpectedExistingUser()
        {
            Assert.Pass();
        }

        [Test]
        public void Users_UpdateUser_ExpectedUpdatedUser()
        {
            Assert.Pass();
        }

        [Test]
        public void Users_DeleteUser_ExpectedNull()
        {
            Assert.Pass();
        }
    }
}