using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.CourseDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Course controller api layer
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> logger;
        private readonly ILogger<CourseBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly CourseBLL courseBLL;
        public CourseController(ILogger<CourseController> logger, ILogger<CourseBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            courseBLL = new CourseBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets course all courses
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CourseDto>> GetCourses()
        {
            logger.LogInformation("From GetCourses action controller");

            try
            {
                var courses = courseBLL.GetCourses().Select(course => course.AsDto()).ToList();
                return courses;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific course by courseId
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{courseId}")]
        public ActionResult<CourseDto> GetCourse(int courseId)
        {
            logger.LogInformation("From GetCourse by login credentials action controller");
            try
            {
                if (courseId <= 0)
                {
                    return NoContent();
                }

                var course = courseBLL.GetCourse(courseId).AsDto();

                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new course
        /// </summary>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<CourseDto> AddCourse(AddCourseDto courseDto)
        {
            logger.LogInformation("From AddCourse action controller");
            try
            {
                if (courseDto == null)
                {
                    return NoContent();
                }

                // add new course
                var course = new Courses()
                {
                    CourseName = courseDto.CourseName,
                    Description = courseDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newCourse = courseBLL.AddCourse(course).AsDto();
                if (newCourse == null)
                {
                    return NotFound();
                }

                return newCourse;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{courseId}")]
        public ActionResult<CourseDto> UpdateCourse([FromRoute] int courseId, [FromBody] UpdateCourseDto courseDto)
        {
            logger.LogInformation("From UpdateCourse action controller");
            try
            {
                if (courseDto == null)
                {
                    return NoContent();
                }

                // search for course
                var existingCourse = courseBLL.GetCourse(courseId);
                if (existingCourse == null)
                {
                    return NotFound();
                }

                // update course
                var course = new Courses()
                {
                    CourseId = courseId,
                    CourseName = courseDto.CourseName,
                    Description = courseDto.Description,
                    UUID = existingCourse.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedCourse = courseBLL.UpdateCourse(course).AsDto();

                return updatedCourse;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{courseId}")]
        public ActionResult DeleteCourse(int courseId)
        {
            logger.LogInformation("From DeleteCourse action controller");
            try
            {
                if (courseId <= 0)
                {
                    return NoContent();
                }

                courseBLL.DeleteCourse(courseId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
