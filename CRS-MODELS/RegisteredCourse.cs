using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class RegisteredCourse
    {
        [Key]
        public int RegisteredCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int RegistrationStatusId { get; set; }
        public string Grade { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public RegisteredCourse(int registeredCourseId, int studentId, int courseId, int registrationStatusId, string grade, string uUID, DateTime createDateTime)
        {
            RegisteredCourseId = registeredCourseId;
            StudentId = studentId;
            CourseId = courseId;
            RegistrationStatusId = registrationStatusId;
            Grade = grade;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
