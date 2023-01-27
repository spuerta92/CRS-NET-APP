using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Course(int courseId, string courseName, string description, string uUID, DateTime createDateTime)
        {
            CourseId = courseId;
            CourseName = courseName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
