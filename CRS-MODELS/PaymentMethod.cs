using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set;}
        public string Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public PaymentMethod(int paymentMethodId, string paymentMethodName, string description, string uUID, DateTime createDateTime)
        {
            PaymentMethodId = paymentMethodId;
            PaymentMethodName = paymentMethodName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
