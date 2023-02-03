using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.CourseCatalogDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// CourseCatalog controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CourseCatalogController : ControllerBase
    {
        private readonly ILogger<CourseCatalogController> logger;
        private readonly ILogger<CourseCatalogBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly CourseCatalogBLL courseCatalogBLL;
        public CourseCatalogController(ILogger<CourseCatalogController> logger, ILogger<CourseCatalogBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            courseCatalogBLL = new CourseCatalogBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets courseCatalog all courseCatalogs
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CourseCatalogDto>> GetAllCoursesFromCourseCatalog()
        {
            logger.LogInformation("From GetCourseCatalogs action controller");

            try
            {
                var courseCatalogs = courseCatalogBLL.GetAllCoursesFromCourseCatalog().Select(courseCatalog => courseCatalog.AsDto()).ToList();
                return courseCatalogs;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourseCatalogs Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourseCatalogs Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetCourseCatalogs Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific courseCatalog by courseCatalogId
        /// </summary>
        /// <param name="courseCatalogId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{courseId}")]
        public ActionResult<CourseCatalogDto> GetCourseFromCourseCatalog(int courseId)
        {
            logger.LogInformation("From GetCourseCatalog by login credentials action controller");
            try
            {
                if (courseId <= 0)
                {
                    return NoContent();
                }

                var courseCatalog = courseCatalogBLL.GetCourseFromCourseCatalog(courseId).AsDto();

                if (courseCatalog == null)
                {
                    return NotFound();
                }

                return courseCatalog;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new courseCatalog
        /// </summary>
        /// <param name="courseCatalogDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<CourseCatalogDto> AddCourseToCourseCatalog(AddCourseCatalogDto courseCatalogDto)
        {
            logger.LogInformation("From AddCourseCatalog action controller");
            try
            {
                if (courseCatalogDto == null)
                {
                    return NoContent();
                }

                // add new courseCatalog
                var courseCatalog = new CourseCatalogs()
                {
                    CourseId = courseCatalogDto.CourseId,
                    ProfessorId = courseCatalogDto.ProfessorId,
                    DepartmentId = courseCatalogDto.DepartmentId,
                    Prerequisite = courseCatalogDto.Prerequisite,
                    Credits = courseCatalogDto.Credits,
                    Capacity = courseCatalogDto.Capacity,
                    Enrolled = courseCatalogDto.Enrolled,
                    Semester = courseCatalogDto.Semester,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newCourseCatalog = courseCatalogBLL.AddCourseToCourseCatalog(courseCatalog).AsDto();
                if (newCourseCatalog == null)
                {
                    return NotFound();
                }

                return newCourseCatalog;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing courseCatalog
        /// </summary>
        /// <param name="courseCatalogId"></param>
        /// <param name="courseCatalogDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{courseCatalogId}")]
        public ActionResult<CourseCatalogDto> UpdateCourseInCourseCatalog([FromRoute] int courseId, [FromBody] UpdateCourseCatalogDto courseCatalogDto)
        {
            logger.LogInformation("From UpdateCourseCatalog action controller");
            try
            {
                if (courseCatalogDto == null)
                {
                    return NoContent();
                }

                // search for courseCatalog
                var existingCourseCatalog = courseCatalogBLL.GetCourseFromCourseCatalog(courseId);
                if (existingCourseCatalog == null)
                {
                    return NotFound();
                }

                // update courseCatalog
                var courseCatalog = new CourseCatalogs()
                {
                    CourseId = courseCatalogDto.CourseId,
                    ProfessorId = courseCatalogDto.ProfessorId,
                    DepartmentId = courseCatalogDto.DepartmentId,
                    Prerequisite = courseCatalogDto.Prerequisite,
                    Credits = courseCatalogDto.Credits,
                    Capacity = courseCatalogDto.Capacity,
                    Enrolled = courseCatalogDto.Enrolled,
                    Semester = courseCatalogDto.Semester,
                    UUID = existingCourseCatalog.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedCourseCatalog = courseCatalogBLL.UpdateCourseInCourseCatalog(courseCatalog).AsDto();

                return updatedCourseCatalog;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific courseCatalog
        /// </summary>
        /// <param name="courseCatalogId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{courseCatalogId}")]
        public ActionResult DeleteCourseFromCourseCatalog(int courseId)
        {
            logger.LogInformation("From DeleteCourseCatalog action controller");
            try
            {
                if (courseId <= 0)
                {
                    return NoContent();
                }

                courseCatalogBLL.DeleteCourseFromCourseCatalog(courseId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourseCatalog Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
