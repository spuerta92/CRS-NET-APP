using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.UserDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// User controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly ILogger<UserBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly UserBLL userBLL;
        public UserController(ILogger<UserController> logger, ILogger<UserBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            userBLL = new UserBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets user all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            logger.LogInformation("From GetUsers action controller");

            try
            {
                var users = userBLL.GetUsers().Select(user => user.AsDto()).ToList();

                for (var i = 0; i < users.Count; i++)
                {
                    users[i].Password = "************************************";
                }

                return users;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific user by username, password, and roleId combination
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{username}/{password}/{roleId}")]
        public ActionResult<UserDto> GetUser(string username, string password, int roleId)
        {
            logger.LogInformation("From GetUser by login credentials action controller");
            try
            {
                if (username == null)
                {
                    return NoContent();
                }

                if (password == null)
                {
                    return NoContent();
                }

                if (roleId <= 0)
                {
                    return NoContent();
                }

                var user = userBLL.GetUser(username, password, roleId).AsDto();

                if (user == null)
                {
                    return NotFound();
                }

                // hide password
                user.Password = "************************************";

                return user;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{userId}")]
        public ActionResult<UserDto> GetUser(int userId)
        {
            logger.LogInformation("From GetUser by login credentials action controller");
            try
            {
                if (userId <= 0)
                {
                    return NoContent();
                }

                var user = userBLL.GetUser(userId).AsDto();

                if (user == null)
                {
                    return NotFound();
                }

                // hide password
                user.Password = "************************************";

                return user;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<UserDto> AddUser(AddUserDto userDto)
        {
            logger.LogInformation("From AddUser action controller");
            try
            {
                if (userDto == null)
                {
                    return NoContent();
                }

                // add new user
                var user = new Users()
                {
                    UserName = userDto.UserName,
                    Password = userDto.Password,
                    RoleId = userDto.RoleId,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newUser = userBLL.AddUser(user).AsDto();
                if (newUser == null)
                {
                    return NotFound();
                }

                // hide password
                newUser.Password = "************************************";

                return newUser;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{userId}")]
        public ActionResult<UserDto> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserDto userDto)
        {
            logger.LogInformation("From UpdateUser action controller");
            try
            {
                if (userDto == null)
                {
                    return NoContent();
                }

                // search for user
                var existingUser = userBLL.GetUser(userId);
                if (existingUser == null)
                {
                    return NotFound();
                }

                // update user
                var user = new Users()
                {
                    UserId = userId,
                    UserName = userDto.UserName,
                    Password = userDto.Password,
                    RoleId = userDto.RoleId,
                    UUID = existingUser.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedUser = userBLL.UpdateUser(user).AsDto();

                // hide password
                updatedUser.Password = "************************************";

                return updatedUser;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            logger.LogInformation("From DeleteUser action controller");
            try
            {
                if (userId <= 0)
                {
                    return NoContent();
                }

                userBLL.DeleteUser(userId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
