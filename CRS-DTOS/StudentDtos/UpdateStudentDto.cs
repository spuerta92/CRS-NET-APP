using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.StudentDtos
{
    public class UpdateStudentDto
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MajorId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
