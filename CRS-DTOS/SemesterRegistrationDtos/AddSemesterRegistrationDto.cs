using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.SemesterRegistrationDtos
{
    public class AddSemesterRegistrationDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ApprovalStatus { get; set; }
        [Required]
        public int AdminId { get; set; }
        public string Comment { get; set; }
    }
}
