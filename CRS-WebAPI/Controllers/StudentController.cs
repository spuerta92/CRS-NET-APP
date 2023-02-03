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
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly ILogger<StudentBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly StudentBLL studentBLL;
        public StudentController(ILogger<StudentController> logger, ILogger<StudentBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            studentBLL = new StudentBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Get list of students
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets student by studentId
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
                    return NotFound();
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Add a new student
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
                    return NotFound();
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

                return CreatedAtAction(nameof(GetStudent), new { id = newStudent.StudentId }, newStudent);
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Update an existing student
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
                    return NotFound();
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

                return Ok(updatedStudent);
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Delete a specific student
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
                    return NotFound();
                }

                studentBLL.DeleteStudent(studentId);
                return NoContent();
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
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
                    return NotFound();
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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="registerCourse"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult AddCourse([FromBody] RegisteredCourse registerCourse)
        {
            logger.LogInformation("From RegisterCourse action controller");
            try
            {
                if (registerCourse == null)
                {
                    return NotFound();
                }

                var courseRegistration = studentBLL.AddCourse(registerCourse);
                return CreatedAtAction(nameof(GetStudent), new { id = courseRegistration.StudentId} , courseRegistration);

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
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="registerCourse"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult DropCourse([FromBody] RegisteredCourse registerCourse)
        {
            logger.LogInformation("From RegisterCourse action controller");
            try
            {
                if (registerCourse == null)
                {
                    return NotFound();
                }

                studentBLL.DropCourse(registerCourse);
                return NoContent();

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
                return Problem(ex.Message);
            }
        }
    }
}
