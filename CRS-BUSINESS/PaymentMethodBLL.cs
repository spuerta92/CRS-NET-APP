using CRS_DAO;
using CRS_MODELS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class PaymentMethodBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<PaymentMethodBLL> logger;

        public PaymentMethodBLL(ILogger<PaymentMethodBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<PaymentMethods> GetPaymentMethods()
        {
            var paymentMethods = repository.GetPaymentMethods();
            return paymentMethods;
        }

        public PaymentMethods GetPaymentMethod(int paymentMethodId)
        {
            var paymentMethod = repository.GetPaymentMethod(paymentMethodId);
            return paymentMethod;
        }

        public PaymentMethods AddPaymentMethod(PaymentMethods paymentMethod)
        {
            var newPaymentMethod = repository.AddPaymentMethod(paymentMethod);
            return newPaymentMethod;
        }

        public PaymentMethods UpdatePaymentMethod(PaymentMethods paymentMethod)
        {
            var existingPaymentMethod = repository.UpdatePaymentMethod(paymentMethod);
            return existingPaymentMethod;
        }

        public void DeletePaymentMethod(int paymentMethodId)
        {
            repository.DeletePaymentMethod(paymentMethodId);
        }
    }
}
