using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.RoleDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Role controller api layer
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> logger;
        private readonly ILogger<RoleBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly RoleBLL roleBLL;
        public RoleController(ILogger<RoleController> logger, ILogger<RoleBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            roleBLL = new RoleBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets role all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<RoleDto>> GetRoles()
        {
            logger.LogInformation("From GetRoles action controller");

            try
            {
                var roles = roleBLL.GetRoles().Select(role => role.AsDto()).ToList();
                return roles;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetRoles Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetRoles Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetRoles Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific role by roleId
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{roleId}")]
        public ActionResult<RoleDto> GetRole(int roleId)
        {
            logger.LogInformation("From GetRole by login credentials action controller");
            try
            {
                if (roleId <= 0)
                {
                    return NoContent();
                }

                var role = roleBLL.GetRole(roleId).AsDto();

                if (role == null)
                {
                    return NotFound();
                }

                return role;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new role
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<RoleDto> AddRole(AddRoleDto roleDto)
        {
            logger.LogInformation("From AddRole action controller");
            try
            {
                if (roleDto == null)
                {
                    return NoContent();
                }

                // add new role
                var role = new Roles()
                {
                    RoleName = roleDto.RoleName,
                    Description = roleDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newRole = roleBLL.AddRole(role).AsDto();
                if (newRole == null)
                {
                    return NotFound();
                }

                return newRole;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing role
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{roleId}")]
        public ActionResult<RoleDto> UpdateRole([FromRoute] int roleId, [FromBody] UpdateRoleDto roleDto)
        {
            logger.LogInformation("From UpdateRole action controller");
            try
            {
                if (roleDto == null)
                {
                    return NoContent();
                }

                // search for role
                var existingRole = roleBLL.GetRole(roleId);
                if (existingRole == null)
                {
                    return NotFound();
                }

                // update role
                var role = new Roles()
                {
                    RoleName = roleDto.RoleName,
                    Description = roleDto.Description,
                    UUID = existingRole.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedRole = roleBLL.UpdateRole(role).AsDto();

                return updatedRole;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{roleId}")]
        public ActionResult DeleteRole(int roleId)
        {
            logger.LogInformation("From DeleteRole action controller");
            try
            {
                if (roleId <= 0)
                {
                    return NoContent();
                }

                roleBLL.DeleteRole(roleId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddRole Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
