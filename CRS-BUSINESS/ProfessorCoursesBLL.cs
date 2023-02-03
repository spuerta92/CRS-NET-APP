using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class ProfessorCoursesBLL
    {
        private readonly ICrsRepository repository;

        public ProfessorCoursesBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ProfessorCourses> GetProfessorCourses()
        {
            var professorCourses = repository.GetProfessorCourses();
            return professorCourses;
        }

        public ProfessorCourses GetProfessorCourses(int professorCoursesId)
        {
            var professorCourses = repository.GetProfessorCourse(professorCoursesId);
            return professorCourses;
        }

        public ProfessorCourses AddProfessorCourses(ProfessorCourses professorCourses)
        {
            var newProfessorCourses = repository.AddProfessorCourses(professorCourses);
            return newProfessorCourses;
        }

        public ProfessorCourses UpdateProfessorCourses(ProfessorCourses professorCourses)
        {
            var existingProfessorCourses = repository.UpdateProfessorCourses(professorCourses);
            return existingProfessorCourses;
        }

        public void DeleteProfessorCourses(int professorCoursesId)
        {
            repository.DeleteProfessorCourses(professorCoursesId);
        }
    }
}
