using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.PaymentDtos
{
    public class UpdatePaymentDto
    {
        [Required]
        public string PaymentAmount { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
    }
}
