using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.UserDtos;
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
        private readonly UserBLL userBLL;
        public UserController(ILogger<AdminController> logger, ICrsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;

            userBLL = new UserBLL(this.repository);
        }

        [HttpGet("[action]")]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = userBLL.GetUsers().Select(user => user.AsDto());
            return users.ToList();
        }

        [HttpGet("[action]/{username}/{password}/{roleId}")]
        public ActionResult<UserDto> GetUser(string username, string password, int roleId)
        {
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

                return user;
            }
            catch(Exception ex)
            {
                logger.LogError($"Failure in GetUser Controller Action: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("[action]")]
        public ActionResult UpdatePassword()
        {
            return Ok();
        }
    }
}
