using CRS_DAO;
using CRS_MODELS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_EXCEPTIONS;

namespace CRS_BUSINESS
{
    /// <summary>
    /// User service logic layer
    /// </summary>
    public class UserBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<UserBLL> logger;

        public UserBLL(ILogger<UserBLL> logger, ICrsRepository repository) 
        { 
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers()
        {
            logger.LogInformation("From GetUsers service method");

            try
            {
                var users = repository.GetUsers();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving all users");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Users GetUser(string userName, string password, int roleId)
        {
            logger.LogInformation("From GetUser service method");
            try
            {
                // check if user exists
                var user = repository.GetUser(userName, password, roleId);
                if (user == null)
                {
                    throw new UserNotFoundException($"{userName} was not found or does not exist");
                }

                // check if password matches
                if (password != user.Password)
                {
                    throw new IncorrectPasswordException("Provided password was incorrect");
                }

                // student condition (roleId = 3)
                if (user.RoleId == 3)
                {
                    var student = repository.GetStudentByUserId(user.UserId);

                    // check if student exists
                    if (student == null)
                    {
                        throw new StudentNotFoundException("Student was not found or does not exist");
                    }

                    // check that there is existing a registration for the user
                    var semesterRegistration = repository.GetSemesterRegistration(student.StudentId);
                    if (semesterRegistration == null)
                    {
                        throw new StudentNotRegisteredException(
                            $"{student.StudentName} has not registered for the semester");
                    }

                    // check that the registration status is set to 1
                    if (semesterRegistration.ApprovalStatus != 1)
                    {
                        throw new SemesterRegistrationNotApprovedException(
                            $"Semester registration for {student.StudentName} has not been approved");
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users GetUser(int userId)
        {
            logger.LogInformation("From GetUser (by userId) service method");

            try
            {
                var user = repository.GetUser(userId);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving user");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users AddUser(Users user)
        {
            logger.LogInformation("From AddUser service method");

            try
            {
                var newUser = repository.AddUser(user);
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error adding user");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users UpdateUser(Users user)
        {
            logger.LogInformation("From UpdateUser service method");
            try
            {
                var existingUser = repository.GetUser(user.UserId);

                // check if user exists
                if (existingUser == null)
                {
                    throw new UserNotFoundException($"User {user.UserName} was not found or does not exist");
                }

                // check if user password matches
                if (user.Password != existingUser.Password)
                {
                    throw new IncorrectPasswordException("Provided password was incorrect");
                }

                var updatedUser = repository.UpdateUser(user);
                return updatedUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId)
        {
            logger.LogInformation("From DeleteUser service method");

            try
            {
                repository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user");
            }
        }
    }
}
