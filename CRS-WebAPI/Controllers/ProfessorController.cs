using CRS_BUSINESS;
using CRS_DAO;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using CRS_COMMON;
using CRS_DTOS.ProfessorDtos;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Professor controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ILogger<ProfessorController> logger;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly ProfessorBLL professorBLL;
        public ProfessorController(ILogger<ProfessorController> logger, ICrsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;

            professorBLL = new ProfessorBLL(repository);
            log = new DbLogger(repository);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<ProfessorDto>> GetProfessors()
        {
            logger.LogInformation("From GetProfessors action controller");

            try
            {
                var professors = professorBLL.GetProfessors();
                return professors.Select(Professor => Professor.AsDto()).ToList();
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetProfessors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetProfessors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetProfessors Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("[action]/{professorId}")]
        public ActionResult<ProfessorDto> GetProfessor(int professorId)
        {
            logger.LogInformation("From GetProfessor by login credentials action controller");
            try
            {
                if (professorId <= 0)
                {
                    return NoContent();
                }

                var Professor = professorBLL.GetProfessor(professorId).AsDto();

                if (Professor == null)
                {
                    return NotFound();
                }

                return Professor;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("[action]")]
        public ActionResult<ProfessorDto> AddProfessor(AddProfessorDto professorDto)
        {
            logger.LogInformation("From AddProfessor action controller");
            try
            {
                if (professorDto == null)
                {
                    return NoContent();
                }

                // add new Professor
                var Professor = new Professors()
                {
                    ProfessorName = professorDto.ProfessorName,
                    UserId = professorDto.UserId,
                    DepartmentId = professorDto.DepartmentId,
                    Email = professorDto.Email,
                    Phone = professorDto.Phone,
                    Address = professorDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newProfessor = professorBLL.AddProfessor(Professor).AsDto();
                if (newProfessor == null)
                {
                    return NotFound();
                }

                return newProfessor;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("[action]/{professorId}")]
        public ActionResult<ProfessorDto> UpdateProfessor([FromRoute] int professorId, [FromBody] UpdateProfessorDto professorDto)
        {
            logger.LogInformation("From UpdateProfessor action controller");
            try
            {
                if (professorDto == null)
                {
                    return NoContent();
                }

                // search for Professor
                var existingProfessor = professorBLL.GetProfessor(professorId);
                if (existingProfessor == null)
                {
                    return NotFound();
                }

                // update Professor
                var Professor = new Professors()
                {
                    ProfessorId = professorId,
                    ProfessorName = professorDto.ProfessorName,
                    UserId = professorDto.UserId,
                    DepartmentId = professorDto.DepartmentId,
                    Email = professorDto.Email,
                    Phone = professorDto.Phone,
                    Address = professorDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };
                var updatedProfessor = professorBLL.UpdateProfessor(Professor).AsDto();

                return updatedProfessor;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("[action]/{professorId}")]
        public ActionResult DeleteProfessor(int professorId)
        {
            logger.LogInformation("From DeleteProfessor action controller");
            try
            {
                if (professorId <= 0)
                {
                    return NoContent();
                }

                professorBLL.DeleteProfessor(professorId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddProfessor Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
