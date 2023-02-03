using CRS_DAO;
using CRS_MODELS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class CourseBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<CourseBLL> logger;

        public CourseBLL(ILogger<CourseBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<Courses> GetCourses()
        {
            var courses = repository.GetCourses();
            return courses;
        }

        public Courses GetCourse(int courseId)
        {
            var course = repository.GetCourse(courseId);
            return course;
        }

        public Courses AddCourse(Courses course)
        {
            var newCourse = repository.AddCourse(course);
            return newCourse;
        }

        public Courses UpdateCourse(Courses course)
        {
            var existingCourse = repository.UpdateCourse(course);
            return existingCourse;
        }

        public void DeleteCourse(int courseId)
        {
            repository.DeleteCourse(courseId);
        }
    }
}
