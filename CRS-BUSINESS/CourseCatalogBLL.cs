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

        public IEnumerable<CourseCatalogs> GetAllCoursesFromCourseCatalog()
        {
            var courses = repository.GetAllCoursesFromCourseCatalog();
            return courses;
        }

        public CourseCatalogs GetCourseFromCourseCatalog(int courseId)
        {
            var course = repository.GetCourseFromCourseCatalog(courseId);
            return course;
        }

        public CourseCatalogs AddCourseToCourseCatalog(CourseCatalogs course)
        {
            var newCourse = repository.AddCourseToCourseCatalog(course);
            return newCourse;
        }

        public CourseCatalogs UpdateCourseInCourseCatalog(CourseCatalogs course)
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
