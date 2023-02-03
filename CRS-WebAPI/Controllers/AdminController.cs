using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Admin controller api layer
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
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
