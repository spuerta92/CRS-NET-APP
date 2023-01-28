using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.UserDtos;
using CRS_MODELS;
using CRS_WebAPI.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        private readonly ICrsRepository repository;
        private readonly Logger log;
        private readonly UserBLL userBLL;
        public UserController(ILogger<AdminController> logger, ICrsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;

            userBLL = new UserBLL(this.repository);
            log = new Logger(repository);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            logger.LogInformation("From GetUsers action controller");

            var users = userBLL.GetUsers().Select(user => user.AsDto()).ToList();

            try
            {
                if (users == null)
                {
                    return NotFound();
                }

                for(var i = 0; i < users.Count; i++)
                {
                    users[i].Password = "************************************";
                }

                return users;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUsers Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

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
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

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
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

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
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("[action]/{userId}")]
        public ActionResult<UserDto> UpdateUser([FromRoute]int userId, [FromBody]UpdateUserDto userDto)
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
                    UserId = existingUser.UserId,
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
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

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
                log.ApiError(ex);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddUser Controller Action: {ex}");
                log.ApiError(ex);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
