using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class RegistrationStatus
    {
        [Key]
        public int RegistrationStatusId { get; set; }
        public string RegistrationStatusName { get; set; }
        public string Description { get; set; }
<<<<<<< HEAD
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
=======
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
>>>>>>> a113c99bf437f70cfa726660e3327fbc0878161b
    }
}
