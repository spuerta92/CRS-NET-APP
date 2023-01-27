using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers.Admin
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        public AdminController(ILogger<AdminController> logger) 
        {
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public ActionResult GetAdmin()
        {
            return Ok();
        }
    }
}
