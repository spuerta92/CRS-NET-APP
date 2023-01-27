using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Payment
    {
        public Payment(int paymentId, string paymentName, int studentId, DateTime dueDate, string semester, int paymentMethodId, byte isPaid, string uUID, DateTime createDateTime)
        {
            PaymentId = paymentId;
            PaymentName = paymentName;
            StudentId = studentId;
            DueDate = dueDate;
            Semester = semester;
            PaymentMethodId = paymentMethodId;
            IsPaid = isPaid;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }

        [Key]
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public int StudentId { get; set; }
        public DateTime DueDate { get; set; }
        public string Semester { get; set; }
        public int PaymentMethodId { get; set; }
        public byte IsPaid { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
