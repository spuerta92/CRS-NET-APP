using CRS_MODELS;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO.EntityFramework
{
    /// <summary>
    /// Database layer
    /// </summary>
    public class EFCrsRepository : ICrsRepository
    {
        private readonly CrsContext db;
        private readonly DbLogger log;
        public EFCrsRepository(CrsContext db)
        {
            this.db = db;
            log = new DbLogger();
        }

        public Admin AddAdmin(Admin admin)
        {
            try
            {
                db.Add(admin);
                db.SaveChanges();
            }
            catch(SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Admin.Where(x => x.AdminId == admin.AdminId).SingleOrDefault();
            return result;
        }

        public Course AddCourse(Course course)
        {
            try
            {
                db.Add(course);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Courses.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
            return result;
        }

        public CourseCatalog AddCourseToCourseCatalog(CourseCatalog course)
        {
            try
            {
                db.Add(course);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.CourseCatalog.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
            return result;
        }

        public Department AddDepartment(Department deparment)
        {
            try
            {
                db.Add(deparment);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Departments.Where(x => x.DepartmentId == deparment.DepartmentId).SingleOrDefault();
            return result;
        }

        public void AddErrorLog(ApiErrorLog log)
        {
            try
            {
                db.Add(log);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddErrorLog(DbErrorLog log)
        {
            try
            {
                db.Add(log);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Major AddMajor(Major major)
        {
            try
            {
                db.Add(major);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Majors.Where(x => x.MajorId == major.MajorId).SingleOrDefault();
            return result;
        }

        public Payment AddPayment(Payment payment)
        {
            try
            {
                db.Add(payment);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Payment.Where(x => x.PaymentId == payment.PaymentId).SingleOrDefault();
            return result;
        }

        public PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                db.Add(paymentMethod);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.PaymentMethods.Where(x => x.PaymentMethodId == paymentMethod.PaymentMethodId).SingleOrDefault();
            return result;
        }

        public Professors AddProfessor(Professors professor)
        {
            try
            {
                db.Add(professor);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Professors.Where(x => x.ProfessorId == professor.ProfessorId).SingleOrDefault();
            return result;
        }

        public ProfessorCourses AddProfessorCourses(ProfessorCourses professorCourse)
        {
            try
            {
                db.Add(professorCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.ProfessorCourses.Where(x => x.ProfessorCoursesId == professorCourse.ProfessorCoursesId).SingleOrDefault();
            return result;
        }

        public RegisteredCourse AddRegisteredCourse(RegisteredCourse registeredCourse)
        {
            try
            {
                db.Add(registeredCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.RegisteredCourses.Where(x => x.RegisteredCourseId == registeredCourse.RegisteredCourseId).SingleOrDefault();
            return result;
        }

        public RegistrationStatus AddRegistrationStatus(RegistrationStatus registrationStatus)
        {
            try
            {
                db.Add(registrationStatus);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.RegistrationStatus.Where(x => x.RegistrationStatusId == registrationStatus.RegistrationStatusId).SingleOrDefault();
            return result;
        }

        public Role AddRole(Role role)
        {
            try
            {
                db.Add(role);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Roles.Where(x => x.RoleId == role.RoleId).SingleOrDefault();
            return result;
        }

        public SemesterRegistration AddSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            try
            {
                db.Add(semesterRegistration);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.SemesterRegistration.Where(x => x.RegistrationId == semesterRegistration.RegistrationId).SingleOrDefault();
            return result;
        }

        public Students AddStudent(Students student)
        {
            try
            {
                db.Add(student);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Students.Where(x => x.StudentId == student.StudentId).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Users AddUser(Users user)
        {
            try
            {
                db.Add(user);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }

            var result = db.Users.Where(x => x.UserId == user.UserId).SingleOrDefault();
            return result;
        }

        public void DeleteAdmin(int adminId)
        {
            try
            {
                var admin = db.Admin.Where(x => x.AdminId == adminId).SingleOrDefault();
                db.Admin.Remove(admin);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                var course = db.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteCourseFromCourseCatalog(int courseId)
        {
            try
            {
                var courseCatalogItem = db.CourseCatalog.Where(x => x.CourseId == courseId).SingleOrDefault();
                db.CourseCatalog.Remove(courseCatalogItem);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteDepartment(int deparmentId)
        {
            try
            {
                var department = db.Departments.Where(x => x.DepartmentId == deparmentId).SingleOrDefault();
                db.Departments.Remove(department);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteMajor(int majorId)
        {
            try
            {
                var major = db.Majors.Where(x => x.MajorId == majorId).SingleOrDefault();
                db.Majors.Remove(major);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeletePayment(int paymentId)
        {
            try
            {
                var payment = db.Payment.Where(x => x.PaymentId == paymentId).SingleOrDefault();
                db.Payment.Remove(payment);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeletePaymentMethod(int paymentMethodId)
        {
            try
            {
                var paymentMethod = db.PaymentMethods.Where(x => x.PaymentMethodId == paymentMethodId).SingleOrDefault();
                db.PaymentMethods.Remove(paymentMethod);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteProfessor(int professorId)
        {
            try
            {
                var professor = db.Professors.Where(x => x.ProfessorId == professorId).SingleOrDefault();
                db.Professors.Remove(professor);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteProfessorCourses(int professorCourseId)
        {
            try
            {
                var professorCourse = db.ProfessorCourses.Where(x => x.ProfessorCoursesId == professorCourseId).SingleOrDefault();
                db.ProfessorCourses.Remove(professorCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteRegisteredCourse(int registeredCourseId)
        {
            try
            {
                var registeredCourse = db.RegisteredCourses.Where(x => x.RegisteredCourseId == registeredCourseId).SingleOrDefault();
                db.RegisteredCourses.Remove(registeredCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteRegistrationStatus(int registrationStatusId)
        {
            try
            {
                var registrationStatus = db.RegistrationStatus.Where(x => x.RegistrationStatusId == registrationStatusId).SingleOrDefault();
                db.RegistrationStatus.Remove(registrationStatus);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteRole(int roleId)
        {
            try
            {
                var role = db.Roles.Where(x => x.RoleId == roleId).SingleOrDefault();
                db.Roles.Remove(role);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteSemesterRegistration(int semesterRegistrationId)
        {
            try
            {
                var semesterRegistration = db.SemesterRegistration.Where(x => x.RegistrationId == semesterRegistrationId).SingleOrDefault();
                db.SemesterRegistration.Remove(semesterRegistration);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                var student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
                db.Students.Remove(student);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public RegisteredCourse RegisterForCourse(RegisteredCourse registeredCourse)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteUser(int userId)
        {
            try
            {
                var user = db.Users.Where(x => x.UserId == userId).SingleOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //log.DbError(ex.Message);
                throw;
            }
        }

        public Admin? GetAdmin(int adminId)
        {
            return db.Admin.Where(x => x.AdminId == adminId).SingleOrDefault();
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return db.Admin;
        }

        public IEnumerable<CourseCatalog> GetAllCoursesFromCourseCatalog()
        {
            return db.CourseCatalog;
        }

        public Course? GetCourse(int courseId)
        {
            return db.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();
        }

        public CourseCatalog? GetCourseFromCourseCatalog(int courseId)
        {
            return db.CourseCatalog.Where(x => x.CourseId == courseId).SingleOrDefault();
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses;
        }

        public Department? GetDepartment(int departmentId)
        {
            return db.Departments.Where(x => x.DepartmentId == departmentId).SingleOrDefault();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return db.Departments;
        }

        public Major? GetMajor(int majorId)
        {
            return db.Majors.Where(x => x.MajorId == majorId).SingleOrDefault();
        }

        public IEnumerable<Major> GetMajors()
        {
            return db.Majors;
        }

        public Payment? GetPayment(int paymentId)
        {
            return db.Payment.Where(x => x.PaymentId == paymentId).SingleOrDefault();
        }

        public PaymentMethod? GetPaymentMethod(int paymentMethodId)
        {
            return db.PaymentMethods.Where(x => x.PaymentMethodId == paymentMethodId).SingleOrDefault();
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return db.PaymentMethods;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return db.Payment;
        }

        public Professors? GetProfessor(int professorId)
        {
            return db.Professors.Where(x => x.ProfessorId == professorId).SingleOrDefault();
        }

        public ProfessorCourses? GetProfessorCourse(int professorCourseId)
        {
            return db.ProfessorCourses.Where(x => x.ProfessorCoursesId == professorCourseId).SingleOrDefault();
        }

        public IEnumerable<ProfessorCourses> GetProfessorCourses()
        {
            return db.ProfessorCourses;
        }

        public IEnumerable<Professors> GetProfessors()
        {
            return db.Professors;
        }

        public RegisteredCourse? GetRegisteredCourse(int registeredCourseId)
        {
            return db.RegisteredCourses.Where(x => x.RegisteredCourseId == registeredCourseId).SingleOrDefault();
        }

        public IEnumerable<RegisteredCourse> GetRegisteredCourses()
        {
            return db.RegisteredCourses;
        }

        public RegistrationStatus? GetRegistrationStatus(int registrationStatusId)
        {
            return db.RegistrationStatus.Where(x => x.RegistrationStatusId == registrationStatusId).SingleOrDefault();
        }

        public IEnumerable<RegistrationStatus> GetRegistrationStatuses()
        {
            return db.RegistrationStatus;
        }

        public Role? GetRole(int roleId)
        {
            return db.Roles.Where(x => x.RoleId == roleId).SingleOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            return db.Roles;
        }

        public SemesterRegistration? GetSemesterRegistration(int semesterRegistrationId)
        {
            return db.SemesterRegistration.Where(x => x.RegistrationId == semesterRegistrationId).SingleOrDefault();
        }

        public IEnumerable<SemesterRegistration> GetSemesterRegistrations()
        {
            return db.SemesterRegistration;
        }

        public Students? GetStudent(int studentId)
        {
            return db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();
        }

        public IEnumerable<Students> GetStudents()
        {
            return db.Students;
        }

        /// <summary>
        /// Get a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users? GetUser(int userId)
        {
            return db.Users.Where(x => x.UserId == userId).SingleOrDefault();
        }

        /// <summary>
        /// Gets a specific user by username, password, roleId combination
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Users? GetUser(string userName, string password, int roleId)
        {
            return db.Users.Where(x => x.UserName == userName && x.Password == password && x.RoleId == roleId).SingleOrDefault();
        }

        /// <summary>
        /// Gets a list of all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers()
        {
            return db.Users;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            try
            {
                var existingAdmin = db.Admin.Where(x => x.AdminId == admin.AdminId).SingleOrDefault();
                db.Entry<Admin>(existingAdmin).CurrentValues.SetValues(admin);
                db.SaveChanges();
            }
            catch(SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message); 
            }

            return db.Admin.Where(x => x.AdminId == admin.AdminId).SingleOrDefault();
        }

        public Course UpdateCourse(Course course)
        {
            try
            {
                var existingCourse = db.Courses.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
                db.Entry<Course>(existingCourse).CurrentValues.SetValues(course);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Courses.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
        }

        public CourseCatalog UpdateCourseInCourseCatalog(CourseCatalog course)
        {
            try
            {
                var existingCourseCatalogItem = db.CourseCatalog.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
                db.Entry<CourseCatalog>(existingCourseCatalogItem).CurrentValues.SetValues(course);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.CourseCatalog.Where(x => x.CourseId == course.CourseId).SingleOrDefault();
        }

        public Department UpdateDepartment(Department deparment)
        {
            try
            {
                var existingDepartment = db.Departments.Where(x => x.DepartmentId == deparment.DepartmentId).SingleOrDefault();
                db.Entry<Department>(existingDepartment).CurrentValues.SetValues(deparment);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Departments.Where(x => x.DepartmentId == deparment.DepartmentId).SingleOrDefault();
        }

        public Major UpdateMajor(Major major)
        {
            try
            {
                var existingMajor = db.Majors.Where(x => x.MajorId == major.MajorId).SingleOrDefault();
                db.Entry<Major>(existingMajor).CurrentValues.SetValues(major);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Majors.Where(x => x.MajorId == major.MajorId).SingleOrDefault();
        }

        public Payment UpdatePayment(Payment payment)
        {
            try
            {
                var existingPayment = db.Payment.Where(x => x.PaymentId == payment.PaymentId).SingleOrDefault();
                db.Entry<Payment>(existingPayment).CurrentValues.SetValues(payment);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Payment.Where(x => x.PaymentId == payment.PaymentId).SingleOrDefault();
        }

        public PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            try
            {
                var existingPaymentMethod = db.PaymentMethods.Where(x => x.PaymentMethodId == paymentMethod.PaymentMethodId).SingleOrDefault();
                db.Entry<PaymentMethod>(existingPaymentMethod).CurrentValues.SetValues(paymentMethod);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.PaymentMethods.Where(x => x.PaymentMethodId == paymentMethod.PaymentMethodId).SingleOrDefault();
        }

        public Professors UpdateProfessor(Professors professor)
        {
            try
            {
                var existingProfessor = db.Professors.Where(x => x.ProfessorId == professor.ProfessorId).SingleOrDefault();
                db.Entry<Professors>(existingProfessor).CurrentValues.SetValues(professor);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Professors.Where(x => x.ProfessorId == professor.ProfessorId).SingleOrDefault();
        }

        public ProfessorCourses UpdateProfessorCourses(ProfessorCourses professorCourse)
        {
            try
            {
                var existingProfessorCourse = db.ProfessorCourses.Where(x => x.ProfessorCoursesId == professorCourse.ProfessorCoursesId).SingleOrDefault();
                db.Entry<ProfessorCourses>(existingProfessorCourse).CurrentValues.SetValues(existingProfessorCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.ProfessorCourses.Where(x => x.ProfessorCoursesId == professorCourse.ProfessorCoursesId).SingleOrDefault();
        }

        public RegisteredCourse UpdateRegisteredCourse(RegisteredCourse registeredCourse)
        {
            try
            {
                var existingRegisteredCourse = db.RegisteredCourses.Where(x => x.RegisteredCourseId == registeredCourse.RegisteredCourseId).SingleOrDefault();
                db.Entry<RegisteredCourse>(existingRegisteredCourse).CurrentValues.SetValues(registeredCourse);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.RegisteredCourses.Where(x => x.RegisteredCourseId == registeredCourse.RegisteredCourseId).SingleOrDefault();
        }

        public RegistrationStatus UpdateRegistrationStatus(RegistrationStatus registrationStatus)
        {
            try
            {
                var existingRegistrationStatus= db.RegistrationStatus.Where(x => x.RegistrationStatusId == registrationStatus.RegistrationStatusId).SingleOrDefault();
                db.Entry<RegistrationStatus>(existingRegistrationStatus).CurrentValues.SetValues(registrationStatus);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.RegistrationStatus.Where(x => x.RegistrationStatusId == registrationStatus.RegistrationStatusId).SingleOrDefault();
        }

        public Role UpdateRole(Role role)
        {
            try
            {
                var existingRole = db.Roles.Where(x => x.RoleId == role.RoleId).SingleOrDefault();
                db.Entry<Role>(existingRole).CurrentValues.SetValues(role);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Roles.Where(x => x.RoleId == role.RoleId).SingleOrDefault();
        }

        public SemesterRegistration UpdateSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            try
            {
                var existingSemesterRegistration = db.SemesterRegistration.Where(x => x.RegistrationId == semesterRegistration.RegistrationId).SingleOrDefault();
                db.Entry<SemesterRegistration>(existingSemesterRegistration).CurrentValues.SetValues(semesterRegistration);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.SemesterRegistration.Where(x => x.RegistrationId == semesterRegistration.RegistrationId).SingleOrDefault();
        }

        public Students UpdateStudent(Students student)
        {
            try
            {
                var existingStudent = db.Students.SingleOrDefault(x => x.StudentId == student.StudentId);
                db.Entry<Students>(existingStudent).CurrentValues.SetValues(student);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Students.Where(x => x.StudentId == student.StudentId).SingleOrDefault();
        }

        /// <summary>
        /// Updates data of a specific user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Users UpdateUser(Users user)
        {
            try
            {
                var existingUser = db.Users.SingleOrDefault(x => x.UserId == user.UserId);
                db.Entry<Users>(existingUser).CurrentValues.SetValues(user);
                db.SaveChanges();
            }
            catch (SqlException ex)
            {
                //log.DbError(ex.Message);
                throw new Exception(ex.Message);
            }

            return db.Users.Where(x => x.UserId == user.UserId).SingleOrDefault();
        }

        public SemesterRegistration? GetSemesterRegistrationByStudentId(int studentId)
        {
            return db.SemesterRegistration.Where(x => x.StudentId == studentId).SingleOrDefault();
        }

        public Students? GetStudentByUserId(int userId)
        {
            return db.Students.Where(x => x.UserId == userId).SingleOrDefault();
        }
    }
}
