using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.ProfessorCoursesDtos
{
    public class ProfessorCoursesDto
    {
        public int ProfessorCoursesId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
