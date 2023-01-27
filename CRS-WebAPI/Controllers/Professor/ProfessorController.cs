using CRS_WebAPI.Controllers.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers.Professor
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        public ProfessorController(ILogger<AdminController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public ActionResult GetProfessor()
        {
            return Ok();
        }
    }
}
