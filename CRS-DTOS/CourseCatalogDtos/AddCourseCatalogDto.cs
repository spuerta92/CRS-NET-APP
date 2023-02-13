using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.CourseCatalogDtos
{
    public class AddCourseCatalogDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int ProfessorId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string? Prerequisite { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Enrolled { get; set; }
        [Required]
        public string Semester { get; set; }
    }
}
