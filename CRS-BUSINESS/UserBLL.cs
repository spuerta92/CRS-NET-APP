using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class UserBLL
    {
        private readonly ICrsRepository repository;

        public UserBLL(ICrsRepository repository) 
        { 
            this.repository = repository;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = repository.GetUsers();
            return users;
        }

        public Users GetUser(string userName, string password, int roleId)
        {
            var users = repository.GetUser(userName, password, roleId);
            return users;
        }

        public Users GetUser(int userId)
        {
            var user = repository.GetUser(userId);
            return user;
        }

        public Users AddUser(Users user)
        {
            var newUser = repository.AddUser(user);
            return newUser;
        }

        public Users UpdateUser(Users user)
        {
            var existingUser = repository.UpdateUser(user);
            return existingUser;
        }

        public void DeleteUser(int userId)
        {
            repository.DeleteUser(userId);
        }
    }
}
