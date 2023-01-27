using CRS_WebAPI.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        public UserController(ILogger<AdminController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("{username}/{password}/{role}")]
        public ActionResult GetUser()
        {            
            return Ok();
        }

        [HttpPut("UpdatePassword")]
        public ActionResult UpdatePassword()
        {
            return Ok();
        }
    }
}
