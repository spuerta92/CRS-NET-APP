using System.Data.SqlTypes;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.PaymentDtos;
using CRS_DTOS.RegisteredCourseDtos;
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
                    Address = studentDto.Address
                };
                var updatedStudent = studentBLL.UpdateStudent(student).AsDto();

                return Ok(updatedStudent);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in UpdateStudent Controller Action: {ex}");
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
                logger.LogError($"Failure in DeleteStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in DeleteStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in DeleteStudent Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="registerCourseDto"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult RegisterForCourse([FromBody]UpdateRegisteredCourseDto registerCourseDto) 
        {
            logger.LogInformation("From RegisterCourse action controller");
            try
            {
                if (registerCourseDto == null)
                {
                    return NotFound();
                }

                var registerCourse = new RegisteredCourse()
                {
                    StudentId = registerCourseDto.StudentId,
                    CourseId = registerCourseDto.CourseId,
                    RegistrationStatusId = 1
                };

                var courseRegistration = studentBLL.RegisterForCourse(registerCourse);
                return Ok(courseRegistration);

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in RegisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in RegisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in RegisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Unregister for a course
        /// </summary>
        /// <param name="registerCourseDto"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult UnregisterForCourse([FromBody] UpdateRegisteredCourseDto registerCourseDto)
        {
            logger.LogInformation("From UnregisterForCourse action controller");
            try
            {
                if (registerCourseDto == null)
                {
                    return NotFound();
                }

                var registerCourse = new RegisteredCourse()
                {
                    StudentId = registerCourseDto.StudentId,
                    CourseId = registerCourseDto.CourseId,
                    RegistrationStatusId = 2
                };

                var courseRegistration = studentBLL.UnregisterForCourse(registerCourse);
                return Ok(courseRegistration);

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in UnregisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in UnregisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in UnregisterForCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="registerCourseDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult AddCourse([FromBody] AddRegisteredCourseDto registerCourseDto)
        {
            logger.LogInformation("From AddCourse action controller");
            try
            {
                if (registerCourseDto == null)
                {
                    return NotFound();
                }

                var registerCourse = new RegisteredCourse()
                {
                    StudentId = registerCourseDto.StudentId,
                    CourseId = registerCourseDto.CourseId,
                    RegistrationStatusId = 2,
                    Grade = null,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var courseRegistration = studentBLL.AddCourse(registerCourse);
                return CreatedAtAction(nameof(GetStudent), new { id = courseRegistration.StudentId} , courseRegistration);

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
        /// Student course registration
        /// </summary>
        /// <param name="registerCourseDto"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public ActionResult DropCourse([FromBody] DeleteRegisteredCourseDto registerCourseDto)
        {
            logger.LogInformation("From DropCourse action controller");
            try
            {
                if (registerCourseDto == null)
                {
                    return NotFound();
                }

                var registerCourse = new RegisteredCourse()
                {
                    StudentId = registerCourseDto.StudentId,
                    CourseId = registerCourseDto.CourseId
                };

                studentBLL.DropCourse(registerCourse);
                return NoContent();

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in DropCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in DropCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in DropCourse Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// View grades 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{studentId}")]
        public ActionResult<List<Grades>> ViewGrades(int studentId)
        {
            logger.LogInformation("From ViewGrades action controller");
            try
            {
                if (studentId == 0)
                {
                    return NotFound();
                }

                return studentBLL.ViewGrades(studentId).ToList();

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in ViewGrades Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in ViewGrades Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in ViewGrades Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get all courses for a specific student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{studentId}")]
        public ActionResult<List<Courses>> GetStudentCourses(int studentId)
        {
            logger.LogInformation("From GetStudentCourses action controller");
            try
            {
                if (studentId == 0)
                {
                    return NotFound();
                }

                return studentBLL.GetStudentCourses(studentId).ToList();

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetStudentCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get all registered courses for a specific student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{studentId}")]
        public ActionResult<List<Courses>> GetStudentRegisteredCourses(int studentId)
        {
            logger.LogInformation("From GetStudentRegisteredCourses action controller");
            try
            {
                if (studentId == 0)
                {
                    return NotFound();
                }

                return studentBLL.GetStudentRegisteredCourses(studentId).ToList();

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentRegisteredCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentRegisteredCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetStudentRegisteredCourses Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Make a payment for registered courses
        /// </summary>
        /// <param name="paymentDto"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult Payment([FromBody]UpdatePaymentDto paymentDto)
        {
            logger.LogInformation("From Payment action controller");
            try
            {
                if (paymentDto == null)
                {
                    return NotFound();
                }

                var payment = new Payment()
                {
                    PaymentAmount = paymentDto.PaymentAmount,
                    StudentId = paymentDto.StudentId,
                    DueDate = paymentDto.DueDate,
                    Semester = paymentDto.Semester,
                    PaymentMethodId = paymentDto.PaymentMethodId,
                    IsPaid = 1
                };

                studentBLL.Payment(payment);

                return NoContent();

            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in Payment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in Payment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in Payment Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
