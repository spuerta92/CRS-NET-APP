using CRS_DAO;
using CRS_MODELS;
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

        public CourseBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Course> GetCourses()
        {
            var courses = repository.GetCourses();
            return courses;
        }

        public Course GetCourse(int courseId)
        {
            var course = repository.GetCourse(courseId);
            return course;
        }

        public Course AddCourse(Course course)
        {
            var newCourse = repository.AddCourse(course);
            return newCourse;
        }

        public Course UpdateCourse(Course course)
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
