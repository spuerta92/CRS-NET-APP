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
    public class CourseCatalogBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<CourseCatalogBLL> logger;

        public CourseCatalogBLL(ILogger<CourseCatalogBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<CourseCatalog> GetAllCoursesFromCourseCatalog()
        {
            var courses = repository.GetAllCoursesFromCourseCatalog();
            return courses;
        }

        public CourseCatalog GetCourseFromCourseCatalog(int courseId)
        {
            var course = repository.GetCourseFromCourseCatalog(courseId);
            return course;
        }

        public CourseCatalog AddCourseToCourseCatalog(CourseCatalog course)
        {
            var newCourse = repository.AddCourseToCourseCatalog(course);
            return newCourse;
        }

        public CourseCatalog UpdateCourseInCourseCatalog(CourseCatalog course)
        {
            var existingCourse = repository.UpdateCourseInCourseCatalog(course);
            return existingCourse;
        }

        public void DeleteCourseFromCourseCatalog(int courseId)
        {
            repository.DeleteCourseFromCourseCatalog(courseId);
        }
    }
}
