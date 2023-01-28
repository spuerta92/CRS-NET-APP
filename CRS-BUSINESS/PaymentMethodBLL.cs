using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class PaymentMethodMethodBLL
    {
        private readonly ICrsRepository repository;

        public PaymentMethodMethodBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            var paymentMethods = repository.GetPaymentMethods();
            return paymentMethods;
        }

        public PaymentMethod GetPaymentMethod(int paymentMethodId)
        {
            var paymentMethod = repository.GetPaymentMethod(paymentMethodId);
            return paymentMethod;
        }

        public PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod)
        {
            var newPaymentMethod = repository.AddPaymentMethod(paymentMethod);
            return newPaymentMethod;
        }

        public PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod)
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
