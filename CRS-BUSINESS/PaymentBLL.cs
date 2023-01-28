using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class PaymentBLL
    {
        private readonly ICrsRepository repository;

        public PaymentBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Payment> GetPayments()
        {
            var payments = repository.GetPayments();
            return payments;
        }

        public Payment GetPayment(int paymentId)
        {
            var payment = repository.GetPayment(paymentId);
            return payment;
        }

        public Payment AddPayment(Payment payment)
        {
            var newPayment = repository.AddPayment(payment);
            return newPayment;
        }

        public Payment UpdatePayment(Payment payment)
        {
            var existingPayment = repository.UpdatePayment(payment);
            return existingPayment;
        }

        public void DeletePayment(int paymentId)
        {
            repository.DeletePayment(paymentId);
        }
    }
}
