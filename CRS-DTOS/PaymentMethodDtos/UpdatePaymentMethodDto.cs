using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.PaymentMethodDtos
{
    public class UpdatePaymentMethodDto
    {
        [Required]
        public string PaymentMethodName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
