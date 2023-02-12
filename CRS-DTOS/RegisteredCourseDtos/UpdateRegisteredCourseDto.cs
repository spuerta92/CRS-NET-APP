using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRS_DTOS.RegisteredCourseDtos
{
    public class UpdateRegisteredCourseDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [JsonIgnore]
        public int RegistrationStatusId { get; set; }
    }
}
