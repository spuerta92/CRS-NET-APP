using System.Data.SqlTypes;
using System.Net;
using CRS_BUSINESS;
using CRS_COMMON;
using CRS_DAO;
using CRS_DTOS.PaymentMethodDtos;
using CRS_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace CRS_WebAPI.Controllers
{
    /// <summary>
    /// PaymentMethod controller api layer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly ILogger<PaymentMethodController> logger;
        private readonly ILogger<PaymentMethodBLL> loggerBLL;
        private readonly ICrsRepository repository;
        private readonly DbLogger log;
        private readonly PaymentMethodBLL paymentMethodBLL;
        public PaymentMethodController(ILogger<PaymentMethodController> logger, ILogger<PaymentMethodBLL> loggerBLL, ICrsRepository repository)
        {
            this.logger = logger;
            this.loggerBLL = loggerBLL;
            this.repository = repository;

            paymentMethodBLL = new PaymentMethodBLL(this.loggerBLL, this.repository);
            log = new DbLogger(this.repository);
        }

        /// <summary>
        /// Gets paymentMethod all paymentMethods
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<PaymentMethodDto>> GetPaymentMethods()
        {
            logger.LogInformation("From GetPaymentMethods action controller");

            try
            {
                var paymentMethods = paymentMethodBLL.GetPaymentMethods().Select(paymentMethod => paymentMethod.AsDto()).ToList();
                return paymentMethods;
            }
            catch (SqlNullValueException ex)
            {
                return NotFound();
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetPaymentMethods Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetPaymentMethods Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetPaymentMethods Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific paymentMethod by paymentMethodId
        /// </summary>
        /// <param name="paymentMethodId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{paymentMethodId}")]
        public ActionResult<PaymentMethodDto> GetPaymentMethod(int paymentMethodId)
        {
            logger.LogInformation("From GetPaymentMethod by login credentials action controller");
            try
            {
                if (paymentMethodId <= 0)
                {
                    return NoContent();
                }

                var paymentMethod = paymentMethodBLL.GetPaymentMethod(paymentMethodId).AsDto();

                if (paymentMethod == null)
                {
                    return NotFound();
                }

                return paymentMethod;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in GetPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in GetPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in GetPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new paymentMethod
        /// </summary>
        /// <param name="paymentMethodDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public ActionResult<PaymentMethodDto> AddPaymentMethod(AddPaymentMethodDto paymentMethodDto)
        {
            logger.LogInformation("From AddPaymentMethod action controller");
            try
            {
                if (paymentMethodDto == null)
                {
                    return NoContent();
                }

                // add new paymentMethod
                var paymentMethod = new PaymentMethods()
                {
                    PaymentMethodName = paymentMethodDto.PaymentMethodName,
                    Description = paymentMethodDto.Description,
                    UUID = Guid.NewGuid().ToString(),
                    CreateDateTime = DateTime.Now
                };

                var newPaymentMethod = paymentMethodBLL.AddPaymentMethod(paymentMethod).AsDto();
                if (newPaymentMethod == null)
                {
                    return NotFound();
                }

                return newPaymentMethod;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updates data for an existing paymentMethod
        /// </summary>
        /// <param name="paymentMethodId"></param>
        /// <param name="paymentMethodDto"></param>
        /// <returns></returns>
        [HttpPut("[action]/{paymentMethodId}")]
        public ActionResult<PaymentMethodDto> UpdatePaymentMethod([FromRoute] int paymentMethodId, [FromBody] UpdatePaymentMethodDto paymentMethodDto)
        {
            logger.LogInformation("From UpdatePaymentMethod action controller");
            try
            {
                if (paymentMethodDto == null)
                {
                    return NoContent();
                }

                // search for paymentMethod
                var existingPaymentMethod = paymentMethodBLL.GetPaymentMethod(paymentMethodId);
                if (existingPaymentMethod == null)
                {
                    return NotFound();
                }

                // update paymentMethod
                var paymentMethod = new PaymentMethods()
                {
                    PaymentMethodName = paymentMethodDto.PaymentMethodName,
                    Description = paymentMethodDto.Description,
                    UUID = existingPaymentMethod.UUID,
                    CreateDateTime = DateTime.Now
                };
                var updatedPaymentMethod = paymentMethodBLL.UpdatePaymentMethod(paymentMethod).AsDto();

                return updatedPaymentMethod;
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific paymentMethod
        /// </summary>
        /// <param name="paymentMethodId"></param>
        /// <returns></returns>
        [HttpDelete("[action]/{paymentMethodId}")]
        public ActionResult DeletePaymentMethod(int paymentMethodId)
        {
            logger.LogInformation("From DeletePaymentMethod action controller");
            try
            {
                if (paymentMethodId <= 0)
                {
                    return NoContent();
                }

                paymentMethodBLL.DeletePaymentMethod(paymentMethodId);
            }
            catch (BadHttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(ex.StatusCode, "Bad Request");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode((int)ex.StatusCode, "Bad Request");
            }
            catch (Exception ex)
            {
                logger.LogError($"Failure in AddPaymentMethod Controller Action: {ex}");
                //log.ApiError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

            return NoContent();
        }
    }
}
