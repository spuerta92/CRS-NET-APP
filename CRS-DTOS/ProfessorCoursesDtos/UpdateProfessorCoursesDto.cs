using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.ProfessorCoursesDtos
{
    public class UpdateProfessorCoursesDto
    {
        [Required]
        public int ProfessorId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
