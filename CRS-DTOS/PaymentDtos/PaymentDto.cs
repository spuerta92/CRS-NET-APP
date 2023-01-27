using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.PaymentDtos
{
    public class PaymentDto
    {
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
