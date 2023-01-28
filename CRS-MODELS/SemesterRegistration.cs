using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class SemesterRegistration
    {
        [Key]
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int ApprovalStatus { get; set; }
        public int AdminId { get; set; }
        public string Comment { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
