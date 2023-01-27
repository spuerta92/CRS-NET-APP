using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.CourseDtos
{
    public class AddCourseDto
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
