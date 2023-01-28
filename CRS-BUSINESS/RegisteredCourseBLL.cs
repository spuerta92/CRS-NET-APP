using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class RegisteredCourseBLL
    {
        private readonly ICrsRepository repository;

        public RegisteredCourseBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<RegisteredCourse> GetRegisteredCourses()
        {
            var registeredCourses = repository.GetRegisteredCourses();
            return registeredCourses;
        }

        public RegisteredCourse GetRegisteredCourse(int registeredCourseId)
        {
            var registeredCourse = repository.GetRegisteredCourse(registeredCourseId);
            return registeredCourse;
        }

        public RegisteredCourse AddRegisteredCourse(RegisteredCourse registeredCourse)
        {
            var newRegisteredCourse = repository.AddRegisteredCourse(registeredCourse);
            return newRegisteredCourse;
        }

        public RegisteredCourse UpdateRegisteredCourse(RegisteredCourse registeredCourse)
        {
            var existingRegisteredCourse = repository.UpdateRegisteredCourse(registeredCourse);
            return existingRegisteredCourse;
        }

        public void DeleteRegisteredCourse(int registeredCourseId)
        {
            repository.DeleteRegisteredCourse(registeredCourseId);
        }
    }
}
