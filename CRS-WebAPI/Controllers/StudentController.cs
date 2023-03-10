using System.Data.SqlTypes;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.StudentDtos;
using Microsoft.AspNetCore.Mvc;
using CRS_MODELS;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Student controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly StudentBLL studentBLL;
        public StudentController(ILogger logger, ICrsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;

            studentBLL = new StudentBLL(this.logger, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            logger.LogInformation("From GetStudents action controller");

            try
            {
                var students = studentBLL.GetStudents();
                return students.Select(student => student.AsDto()).ToList();
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudents Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudents Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetStudents Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{studentId}")]
        public ActionResult<StudentDto> GetStudent(int studentId)
        {
            logger.LogInformation("From GetStudent by login credentials action controller");
            try
            {
                if (studentId <= 0)
                {
                    return NoContent();
                }

                var student = studentBLL.GetStudent(studentId).AsDto();

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<StudentDto> AddStudent(AddStudentDto studentDto)
        {
            logger.LogInformation("From AddStudent action controller");
            try
            {
                if (studentDto == null)
                {
                    return NoContent();
                }

                // add new student
                var student = new Students()
                {
                    StudentName = studentDto.StudentName,
                    UserId = studentDto.UserId,
                    MajorId = studentDto.MajorId,
                    Email = studentDto.Email,
                    Phone = studentDto.Phone,
                    Address = studentDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newStudent = studentBLL.AddStudent(student).AsDto();
                if (newStudent == null)
                {
                    return NotFound();
                }

                return newStudent;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{studentId}")]
        public ActionResult<StudentDto> UpdateStudent([FromRoute] int studentId, [FromBody] UpdateStudentDto studentDto)
        {
            logger.LogInformation("From UpdateStudent action controller");
            try
            {
                if (studentDto == null)
                {
                    return NoContent();
                }

                // search for student
                var existingStudent = studentBLL.GetStudent(studentId);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                // update student
                var student = new Students()
                {
                    StudentId = studentId,
                    StudentName = studentDto.StudentName,
                    UserId = studentDto.UserId,
                    MajorId = studentDto.MajorId,
                    Email = studentDto.Email,
                    Phone = studentDto.Phone,
                    Address = studentDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };
                var updatedStudent = studentBLL.UpdateStudent(student).AsDto();

                return updatedStudent;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            logger.LogInformation("From DeleteStudent action controller");
            try
            {
                if (studentId <= 0)
                {
                    return NoContent();
                }

                studentBLL.DeleteStudent(studentId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerCourse"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult RegisterForCourse([FromBody]RegisteredCourse registerCourse) 
        {
            logger.LogInformation("From RegisterCourse action controller");
            try
            {
                if (registerCourse == null)
                {
                    return NoContent();
                }
                var courseRegistration = studentBLL.RegisterForCourse(registerCourse);
                return Ok(courseRegistration);

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
