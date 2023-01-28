using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO
{
    public interface ICrsRepository 
    {
        // users
        /// <summary>
        /// Add a user to db
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users AddUser(Users user);

        /// <summary>
        /// Deletes a user from db
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId);

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users UpdateUser(Users user);

        /// <summary>
        /// Gets a user by userId from the db
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users? GetUser(int userId);

        /// <summary>
        /// Gets a user by username, password, and roleId
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Users? GetUser(string userName, string password, int roleId);

        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Users> GetUsers();

        // students
        public Students AddStudent(Students student);
        public void DeleteStudent(int studentId);
        public RegisteredCourse RegisterForCourse(RegisteredCourse registeredCourse);
        public Students UpdateStudent(Students student);
        public Students? GetStudent(int studentId);
        /// <summary>
        /// Gets student by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Students? GetStudentByUserId(int userId);
        public IEnumerable<Students> GetStudents();

        // professors
        public Professors AddProfessor(Professors professor);
        public void DeleteProfessor(int professorId);
        public Professors UpdateProfessor(Professors professor);
        public Professors? GetProfessor(int professorId);
        public IEnumerable<Professors> GetProfessors();

        // admin
        public Admin AddAdmin(Admin admin);
        public void DeleteAdmin(int adminId);
        public Admin UpdateAdmin(Admin admin);
        public Admin? GetAdmin(int adminId);
        public IEnumerable<Admin> GetAdmins();

        // course catalog
        public CourseCatalog AddCourseToCourseCatalog(CourseCatalog course);
        public void DeleteCourseFromCourseCatalog(int courseId);
        public CourseCatalog UpdateCourseInCourseCatalog(CourseCatalog course);
        public CourseCatalog? GetCourseFromCourseCatalog(int courseId);
        public IEnumerable<CourseCatalog> GetAllCoursesFromCourseCatalog();

        // courses
        public Course AddCourse(Course course);
        public void DeleteCourse(int courseId);
        public Course UpdateCourse(Course course);
        public Course? GetCourse(int courseId);
        public IEnumerable<Course> GetCourses();

        // departments
        public Department AddDepartment(Department deparment);
        public void DeleteDepartment(int deparmentId);
        public Department UpdateDepartment(Department deparment);
        public Department? GetDepartment(int deparmentId);
        public IEnumerable<Department> GetDepartments();

        // majors
        public Major AddMajor(Major major);
        public void DeleteMajor(int majorId);
        public Major UpdateMajor(Major major);
        public Major? GetMajor(int majorId);
        public IEnumerable<Major> GetMajors();

        // payment
        public Payment AddPayment(Payment payment);
        public void DeletePayment(int paymentId);
        public Payment UpdatePayment(Payment payment);
        public Payment? GetPayment(int paymentId);
        public IEnumerable<Payment> GetPayments();

        // payment methods
        public PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod);
        public void DeletePaymentMethod(int paymentMethodId);
        public PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod);
        public PaymentMethod? GetPaymentMethod(int paymentMethodId);
        public IEnumerable<PaymentMethod> GetPaymentMethods();

        // registration status
        public RegistrationStatus AddRegistrationStatus(RegistrationStatus registrationStatus);
        public void DeleteRegistrationStatus(int registrationStatusId);
        public RegistrationStatus UpdateRegistrationStatus(RegistrationStatus registrationStatus);
        public RegistrationStatus? GetRegistrationStatus(int registrationStatusId);
        public IEnumerable<RegistrationStatus> GetRegistrationStatuses();

        // roles
        public Role AddRole(Role role);
        public void DeleteRole(int roleId);
        public Role UpdateRole(Role role);
        public Role? GetRole(int roleId);
        public IEnumerable<Role> GetRoles();

        // semester registration
        public SemesterRegistration AddSemesterRegistration(SemesterRegistration semesterRegistration);
        public void DeleteSemesterRegistration(int semesterRegistrationId);
        public SemesterRegistration UpdateSemesterRegistration(SemesterRegistration semesterRegistration);
        public SemesterRegistration? GetSemesterRegistration(int semesterRegistrationId);
        /// <summary>
        /// Get student semester registration by studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public SemesterRegistration? GetSemesterRegistrationByStudentId(int studentId);
        public IEnumerable<SemesterRegistration> GetSemesterRegistrations();

        // professor courses
        public ProfessorCourses AddProfessorCourses(ProfessorCourses professorCourse);
        public void DeleteProfessorCourses(int professorCourseId);
        public ProfessorCourses UpdateProfessorCourses(ProfessorCourses professorCourse);
        public ProfessorCourses? GetProfessorCourse(int professorCourseId);
        public IEnumerable<ProfessorCourses> GetProfessorCourses();

        // registered courses
        public RegisteredCourse AddRegisteredCourse(RegisteredCourse registeredCourse);
        public void DeleteRegisteredCourse(int registeredCourseId);
        public RegisteredCourse UpdateRegisteredCourse(RegisteredCourse registeredCourse);
        public RegisteredCourse? GetRegisteredCourse(int registeredCourseId);
        public IEnumerable<RegisteredCourse> GetRegisteredCourses();

        // logs
        public void AddErrorLog(ApiErrorLog log);
        public void AddErrorLog(DbErrorLog log);
    }
}
