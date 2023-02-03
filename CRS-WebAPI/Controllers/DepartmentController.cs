using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.DepartmentDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Department controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> logger;
        private readonly ILogger<DepartmentBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly DepartmentBLL departmentBLL;
        public DepartmentController(ILogger<DepartmentController> logger, ILogger<DepartmentBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            departmentBLL = new DepartmentBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets department all departments
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<DepartmentDto>> GetDepartments()
        {
            logger.LogInformation("From GetDepartments action controller");

            try
            {
                var departments = departmentBLL.GetDepartments().Select(department => department.AsDto()).ToList();
                return departments;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetDepartments Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetDepartments Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetDepartments Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific department by departmentId
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{departmentId}")]
        public ActionResult<DepartmentDto> GetDepartment(int departmentId)
        {
            logger.LogInformation("From GetDepartment by login credentials action controller");
            try
            {
                if (departmentId <= 0)
                {
                    return NoContent();
                }

                var department = departmentBLL.GetDepartment(departmentId).AsDto();

                if (department == null)
                {
                    return NotFound();
                }

                return department;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new department
        /// </summary>
        /// <param name="departmentDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<DepartmentDto> AddDepartment(AddDepartmentDto departmentDto)
        {
            logger.LogInformation("From AddDepartment action controller");
            try
            {
                if (departmentDto == null)
                {
                    return NoContent();
                }

                // add new department
                var department = new Departments()
                {
                    DepartmentName = departmentDto.DepartmentName,
                    Description = departmentDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newDepartment = departmentBLL.AddDepartment(department).AsDto();
                if (newDepartment == null)
                {
                    return NotFound();
                }

                return newDepartment;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{departmentId}")]
        public ActionResult<DepartmentDto> UpdateDepartment([FromRoute] int departmentId, [FromBody] UpdateDepartmentDto departmentDto)
        {
            logger.LogInformation("From UpdateDepartment action controller");
            try
            {
                if (departmentDto == null)
                {
                    return NoContent();
                }

                // search for department
                var existingDepartment = departmentBLL.GetDepartment(departmentId);
                if (existingDepartment == null)
                {
                    return NotFound();
                }

                // update department
                var department = new Departments()
                {
                    DepartmentName = departmentDto.DepartmentName,
                    Description = departmentDto.Description,
                    UUID = existingDepartment.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedDepartment = departmentBLL.UpdateDepartment(department).AsDto();

                return updatedDepartment;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{departmentId}")]
        public ActionResult DeleteDepartment(int departmentId)
        {
            logger.LogInformation("From DeleteDepartment action controller");
            try
            {
                if (departmentId <= 0)
                {
                    return NoContent();
                }

                departmentBLL.DeleteDepartment(departmentId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddDepartment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
