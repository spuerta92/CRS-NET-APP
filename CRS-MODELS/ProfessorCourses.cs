using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class ProfessorCourses
    {
        public ProfessorCourses(int professorCoursesId, int professorId, int courseId, string uUID, DateTime createDateTime)
        {
            ProfessorCoursesId = professorCoursesId;
            ProfessorId = professorId;
            CourseId = courseId;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }

        [Key]
        public int ProfessorCoursesId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
