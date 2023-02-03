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
        private readonly ILogger<StudentBLL> logger;

        public StudentBLL(ILogger<StudentBLL> logger, ICrsRepository repository)
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
                throw new Exception(ex.Message);
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
        /// Student course registration
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
                var semesterRegistration = repository.GetSemesterRegistrationByStudentId(course.StudentId);
                if (semesterRegistration == null)
                {
                    throw new StudentNotRegisteredException(
                        $"Student has not registered for the semester");
                }

                // check if course exists in course catalog
                var courseCatalog = repository.GetCourseFromCourseCatalog(course.CourseId);
                if (courseCatalog == null)
                {
                    throw new CourseNotFoundException("Course was not found in the course catalog");
                }

                // check if student is already registered for course
                var studentCourseRegistration = repository.GetRegisteredCourseByStudentId(course.StudentId);
                if (studentCourseRegistration == null)
                {
                    throw new StudentCourseNotFoundException("Student course not found");
                }

                // check if there's capacity for the course in the course catalog
                if (courseCatalog.Enrolled >= courseCatalog.Capacity)
                {
                    throw new CannotRegisterForCourseException(
                        "Cannot register for this course. Course is at max capacity");
                }

                // update registration
                var courseRegistration = repository.UpdateRegisteredCourse(course);

                // update course catalog
                if (courseRegistration.RegistrationStatusId == 1)
                {
                    courseCatalog.Enrolled++;
                    repository.UpdateCourseInCourseCatalog(courseCatalog);
                }
                else
                {
                    if (courseCatalog.Enrolled > 0)
                    {
                        courseCatalog.Enrolled--;
                        repository.UpdateCourseInCourseCatalog(courseCatalog);
                    }
                }

                return courseRegistration;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public RegisteredCourse AddCourse(RegisteredCourse course)
        {
            logger.LogInformation("From student AddCourse service method");
            try
            {
                // check student semester registration
                var semesterRegistration = repository.GetSemesterRegistrationByStudentId(course.StudentId);
                if (semesterRegistration == null)
                {
                    throw new StudentNotRegisteredException(
                        $"Student has not registered for the semester");
                }

                // check if course exists in course catalog
                var courseCatalog = repository.GetCourseFromCourseCatalog(course.CourseId);
                if (courseCatalog == null)
                {
                    throw new CourseNotFoundException("Course was not found in the course catalog");
                }

                // check if student is already registered for course
                var studentCourseRegistration = repository.GetRegisteredCourseByStudentId(course.StudentId);
                if (studentCourseRegistration == null)
                {
                    return repository.AddRegisteredCourse(course);
                }
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Student course registration
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void DropCourse(RegisteredCourse course)
        {
            logger.LogInformation("From student DropCourse service method");
            try
            {
                // check if course exists in course catalog
                var courseCatalog = repository.GetCourseFromCourseCatalog(course.CourseId);
                if (courseCatalog == null)
                {
                    throw new CourseNotFoundException("Course was not found in the course catalog");
                }

                // check if student is already registered for course
                var studentCourseRegistration = repository.GetRegisteredCourseByStudentId(course.StudentId);
                if (studentCourseRegistration != null)
                {
                    repository.DeleteRegisteredCourse(course.CourseId);
                    if (courseCatalog.Enrolled > 0)
                    {
                        courseCatalog.Enrolled--;
                        repository.UpdateCourseInCourseCatalog(courseCatalog);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}