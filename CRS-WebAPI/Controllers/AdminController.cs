using CRS_BUSINESS;
using CRS_DTOS.AdminDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.PaymentDtos;
using CRS_DTOS.SemesterRegistrationDtos;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// Admin controller api layer
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        private readonly ICrsRepository repository;
        private readonly AdminBLL adminBLL;
        private readonly DbLogger log;
        public AdminController(ILogger<AdminController> logger, ICrsRepository repository)
        {
            this.logger = logger;
            this.repository = repository;

            adminBLL = new AdminBLL(this.repository);
            log = new DbLogger(this.repository);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<AdminDto>> GetAdmins()
        {
            logger.LogInformation("From GetAdmins action controller");

            try
            {
                var admins = adminBLL.GetAdmins();
                return admins.Select(Admin => Admin.AsDto()).ToList();
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetAdmins Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetAdmins Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetAdmins Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("[action]/{adminId}")]
        public ActionResult<AdminDto> GetAdmin(int adminId)
        {
            logger.LogInformation("From GetAdmin by login credentials action controller");
            try
            {
                if (adminId <= 0)
                {
                    return NoContent();
                }

                var Admin = adminBLL.GetAdmin(adminId).AsDto();

                if (Admin == null)
                {
                    return NotFound();
                }

                return Admin;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("[action]")]
        public ActionResult<AdminDto> AddAdmin(AddAdminDto adminDto)
        {
            logger.LogInformation("From AddAdmin action controller");
            try
            {
                if (adminDto == null)
                {
                    return NoContent();
                }

                // add new Admin
                var admin = new Admin()
                {
                    AdminName = adminDto.AdminName,
                    UserId = adminDto.UserId,
                    Email = adminDto.Email,
                    Phone = adminDto.Phone,
                    Address = adminDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newAdmin = adminBLL.AddAdmin(admin).AsDto();
                if (newAdmin == null)
                {
                    return NotFound();
                }

                return newAdmin;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("[action]/{adminId}")]
        public ActionResult<AdminDto> UpdateAdmin([FromRoute] int adminId, [FromBody] UpdateAdminDto adminDto)
        {
            logger.LogInformation("From UpdateAdmin action controller");
            try
            {
                if (adminDto == null)
                {
                    return NoContent();
                }

                // search for Admin
                var existingAdmin = adminBLL.GetAdmin(adminId);
                if (existingAdmin == null)
                {
                    return NotFound();
                }

                // update Admin
                var Admin = new Admin()
                {
                    AdminId = adminId,
                    AdminName = adminDto.AdminName,
                    UserId = adminDto.UserId,
                    Email = adminDto.Email,
                    Phone = adminDto.Phone,
                    Address = adminDto.Address,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };
                var updatedAdmin = adminBLL.UpdateAdmin(Admin).AsDto();

                return updatedAdmin;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in UpdateAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("[action]/{adminId}")]
        public ActionResult DeleteAdmin(int adminId)
        {
            logger.LogInformation("From DeleteAdmin action controller");
            try
            {
                if (adminId <= 0)
                {
                    return NoContent();
                }

                adminBLL.DeleteAdmin(adminId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in DeleteAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in DeleteAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in DeleteAdmin Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a payment bill record for a specific student
        /// </summary>
        /// <param name="paymentDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult CreatePaymentBill([FromBody]AddPaymentDto paymentDto)
        {
            logger.LogInformation("From CreatePaymentBill action controller");
            try
            {
                if (paymentDto == null)
                {
                    return NoContent();
                }

                var payment = new Payment()
                {
                    PaymentAmount = paymentDto.PaymentAmount,
                    StudentId = paymentDto.StudentId,
                    DueDate = paymentDto.DueDate,
                    Semester = paymentDto.Semester,
                    PaymentMethodId = paymentDto.PaymentMethodId,
                    IsPaid = 0,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                adminBLL.CreatePaymentBill(payment);

                return NoContent();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in CreatePaymentBill Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in CreatePaymentBill Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in CreatePaymentBill Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }

        [HttpPost("[action]")]
        public ActionResult<SemesterRegistrationDto> CreateStudentSemesterRegistration([FromBody] AddSemesterRegistrationDto registrationDto)
        {
            logger.LogInformation("From CreateStudentSemesterRegistration action controller");
            try
            {
                if (registrationDto == null)
                {
                    return NotFound();
                }

                var registration = new SemesterRegistration()
                {
                    StudentId = registrationDto.StudentId,
                    ApprovalStatus = registrationDto.ApprovalStatus,
                    AdminId = registrationDto.AdminId,
                    Comment = registrationDto.Comment,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                return adminBLL.CreateStudentSemesterRegistration(registration).AsDto();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in CreateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in CreateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in CreateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update semester registration
        /// </summary>
        /// <param name="registrationDto"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public ActionResult UpdateStudentSemesterRegistration([FromBody] UpdateSemesterRegistrationDto registrationDto)
        {
            logger.LogInformation("From UpdateStudentSemesterRegistration action controller");
            try
            {
                if (registrationDto == null)
                {
                    return NotFound();
                }

                var existingRegistration = adminBLL.GetStudentSemesterRegistration(registrationDto.StudentId);
                if (existingRegistration == null)
                {
                    return NotFound();
                }

                var registration = new SemesterRegistration()
                {
                    RegistrationId = existingRegistration.StudentId,
                    StudentId = registrationDto.StudentId,
                    ApprovalStatus = registrationDto.ApprovalStatus,
                    AdminId = registrationDto.AdminId,
                    Comment = registrationDto.Comment,
                    UUID = existingRegistration.UUID,
                    CreateDateTime = existingRegistration.CreateDateTime
                };

                adminBLL.UpdateStudentSemesterRegistration(registration);

                return NoContent();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in UpdateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in UpdateStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("[action]/{studentId}")]
        public ActionResult<SemesterRegistrationDto> GetStudentSemesterRegistration(int studentId)
        {
            logger.LogInformation("From GetStudentSemesterRegistration action controller");
            try
            {
                if (studentId == 0)
                {
                    return NotFound();
                }

                return Ok(adminBLL.GetStudentSemesterRegistration(studentId)?.AsDto());
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetStudentSemesterRegistration Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
