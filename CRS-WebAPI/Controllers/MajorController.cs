using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.MajorDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Major controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MajorController : ControllerBase
    {
        private readonly ILogger<MajorController> logger;
        private readonly ILogger<MajorBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly MajorBLL majorBLL;
        public MajorController(ILogger<MajorController> logger, ILogger<MajorBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            majorBLL = new MajorBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets major all majors
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<MajorDto>> GetMajors()
        {
            logger.LogInformation("From GetMajors action controller");

            try
            {
                var majors = majorBLL.GetMajors().Select(major => major.AsDto()).ToList();
                return majors;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetMajors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetMajors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetMajors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific major by majorId
        /// </summary>
        /// <param name="majorId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{majorId}")]
        public ActionResult<MajorDto> GetMajor(int majorId)
        {
            logger.LogInformation("From GetMajor by login credentials action controller");
            try
            {
                if (majorId <= 0)
                {
                    return NoContent();
                }

                var major = majorBLL.GetMajor(majorId).AsDto();

                if (major == null)
                {
                    return NotFound();
                }

                return major;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new major
        /// </summary>
        /// <param name="majorDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<MajorDto> AddMajor(AddMajorDto majorDto)
        {
            logger.LogInformation("From AddMajor action controller");
            try
            {
                if (majorDto == null)
                {
                    return NoContent();
                }

                // add new major
                var major = new Majors()
                {
                    MajorName = majorDto.MajorName,
                    Description = majorDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newMajor = majorBLL.AddMajor(major).AsDto();
                if (newMajor == null)
                {
                    return NotFound();
                }

                return newMajor;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing major
        /// </summary>
        /// <param name="majorId"></param>
        /// <param name="majorDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{majorId}")]
        public ActionResult<MajorDto> UpdateMajor([FromRoute] int majorId, [FromBody] UpdateMajorDto majorDto)
        {
            logger.LogInformation("From UpdateMajor action controller");
            try
            {
                if (majorDto == null)
                {
                    return NoContent();
                }

                // search for major
                var existingMajor = majorBLL.GetMajor(majorId);
                if (existingMajor == null)
                {
                    return NotFound();
                }

                // update major
                var major = new Majors()
                {
                    MajorName = majorDto.MajorName,
                    Description = majorDto.Description,
                    UUID = existingMajor.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedMajor = majorBLL.UpdateMajor(major).AsDto();

                return updatedMajor;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific major
        /// </summary>
        /// <param name="majorId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{majorId}")]
        public ActionResult DeleteMajor(int majorId)
        {
            logger.LogInformation("From DeleteMajor action controller");
            try
            {
                if (majorId <= 0)
                {
                    return NoContent();
                }

                majorBLL.DeleteMajor(majorId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddMajor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
