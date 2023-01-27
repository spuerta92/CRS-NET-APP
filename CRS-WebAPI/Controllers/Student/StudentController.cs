using CRS_WebAPI.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers.Student
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        public StudentController(ILogger<AdminController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public ActionResult GetStudent()
        {
            return Ok();
        }
    }
}
