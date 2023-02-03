using CRS_DAO;
using CRS_EXCEPTIONS;
using CRS_MODELS;
using Microsoft.Extensions.Logging;

namespace CRS_BUSINESS
{
    /// <summary>
    /// Student business logic layer
    /// </summary>
    public class StudentBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger logger;

        public StudentBLL(ILogger logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Students> GetStudents() 
        {
            logger.LogInformation("From GetStudents service method");

            try
            {
                var students = repository.GetStudents();
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving all students");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Students? GetStudent(int studentId)
        {
            logger.LogInformation("From GetStudent service method");

            try
            {
                var student = repository.GetStudent(studentId);
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving student");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Students AddStudent(Students student)
        {
            logger.LogInformation("From AddStudent service method");

            try
            {
                var newStudent = repository.AddStudent(student);
                return newStudent;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error adding new student");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Students UpdateStudent(Students student)
        {
            logger.LogInformation("From UpdateStudent service method");

            try
            {
                var existingStudent = repository.UpdateStudent(student);
                return existingStudent;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error updating student");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        public void DeleteStudent(int studentId)
        {
            logger.LogInformation("From DeleteStudent service method");
            try
            {
                repository.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error deleting student");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public RegisteredCourse RegisterForCourse(RegisteredCourse course)
        {
            logger.LogInformation("From RegisterForCourse service method");
            try
            {
                // check student semester registration

                // check if course exists in course catalog

                // check if student is already registered for course

                // otherwise register student for course
                return repository.RegisterForCourse(course);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error when registering for a course");
            }
        }
    }
}