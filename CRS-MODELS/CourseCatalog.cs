using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class CourseCatalog
    {
        public CourseCatalog(int courseCatalogId, int courseId, int professorId, int departmentId, string prerequisite, int credits, int capacity, int enrolled, string semester, string uUID, DateTime createDateTime)
        {
            CourseCatalogId = courseCatalogId;
            CourseId = courseId;
            ProfessorId = professorId;
            DepartmentId = departmentId;
            Prerequisite = prerequisite;
            Credits = credits;
            Capacity = capacity;
            Enrolled = enrolled;
            Semester = semester;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }

        [Key]
        public int CourseCatalogId { get; set; }
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }
        public int DepartmentId { get; set; }
        public string Prerequisite { get; set; }
        public int Credits { get; set; }
        public int Capacity { get; set; }
        public int Enrolled { get; set; }
        public string Semester { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
