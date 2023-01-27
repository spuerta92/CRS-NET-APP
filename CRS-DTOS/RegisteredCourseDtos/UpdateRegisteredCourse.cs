using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.RegisteredCourseDtos
{
    public class UpdateRegisteredCourse
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int RegistrationStatusId { get; set; }
        [Required]
        public string Grade { get; set; }
    }
}
