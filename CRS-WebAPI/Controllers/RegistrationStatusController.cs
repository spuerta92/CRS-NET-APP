using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.RegistrationStatusDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// RegistrationStatus controller api layer
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegistrationStatusController : ControllerBase
    {
        private readonly ILogger<RegistrationStatusController> logger;
        private readonly ILogger<RegistrationStatusBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly RegistrationStatusBLL registrationStatusBLL;
        public RegistrationStatusController(ILogger<RegistrationStatusController> logger, ILogger<RegistrationStatusBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            registrationStatusBLL = new RegistrationStatusBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets registrationStatus all registrationStatus
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<RegistrationStatusDto>> GetRegistrationStatus()
        {
            logger.LogInformation("From GetRegistrationStatus action controller");

            try
            {
                var registrationStatus = registrationStatusBLL.GetRegistrationStatus().Select(registrationStatus => registrationStatus.AsDto()).ToList();
                return registrationStatus;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific registrationStatus by registrationStatusId
        /// </summary>
        /// <param name="registrationStatusId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{registrationStatusId}")]
        public ActionResult<RegistrationStatusDto> GetRegistrationStatus(int registrationStatusId)
        {
            logger.LogInformation("From GetRegistrationStatus by login credentials action controller");
            try
            {
                if (registrationStatusId <= 0)
                {
                    return NoContent();
                }

                var registrationStatus = registrationStatusBLL.GetRegistrationStatus(registrationStatusId).AsDto();

                if (registrationStatus == null)
                {
                    return NotFound();
                }

                return registrationStatus;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new registrationStatus
        /// </summary>
        /// <param name="registrationStatusDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<RegistrationStatusDto> AddRegistrationStatus(AddRegistrationStatusDto registrationStatusDto)
        {
            logger.LogInformation("From AddRegistrationStatus action controller");
            try
            {
                if (registrationStatusDto == null)
                {
                    return NoContent();
                }

                // add new registrationStatus
                var registrationStatus = new RegistrationStatus()
                {
                    RegistrationStatusName = registrationStatusDto.RegistrationStatusName,
                    Description = registrationStatusDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newRegistrationStatus = registrationStatusBLL.AddRegistrationStatus(registrationStatus).AsDto();
                if (newRegistrationStatus == null)
                {
                    return NotFound();
                }

                return newRegistrationStatus;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing registrationStatus
        /// </summary>
        /// <param name="registrationStatusId"></param>
        /// <param name="registrationStatusDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{registrationStatusId}")]
        public ActionResult<RegistrationStatusDto> UpdateRegistrationStatus([FromRoute] int registrationStatusId, [FromBody] UpdateRegistrationStatusDto registrationStatusDto)
        {
            logger.LogInformation("From UpdateRegistrationStatus action controller");
            try
            {
                if (registrationStatusDto == null)
                {
                    return NoContent();
                }

                // search for registrationStatus
                var existingRegistrationStatus = registrationStatusBLL.GetRegistrationStatus(registrationStatusId);
                if (existingRegistrationStatus == null)
                {
                    return NotFound();
                }

                // update registrationStatus
                var registrationStatus = new RegistrationStatus()
                {
                    RegistrationStatusName = registrationStatusDto.RegistrationStatusName,
                    Description = registrationStatusDto.Description,
                    UUID = existingRegistrationStatus.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedRegistrationStatus = registrationStatusBLL.UpdateRegistrationStatus(registrationStatus).AsDto();

                return updatedRegistrationStatus;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific registrationStatus
        /// </summary>
        /// <param name="registrationStatusId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{registrationStatusId}")]
        public ActionResult DeleteRegistrationStatus(int registrationStatusId)
        {
            logger.LogInformation("From DeleteRegistrationStatus action controller");
            try
            {
                if (registrationStatusId <= 0)
                {
                    return NoContent();
                }

                registrationStatusBLL.DeleteRegistrationStatus(registrationStatusId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRegistrationStatus Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
