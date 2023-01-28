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
        public Users AddUser(Users user);
        public void DeleteUser(int userId);
        public Users UpdateUser(Users user);
        public Users? GetUser(int userId);
        public Users? GetUser(string userName, string password, int roleId);
        public IEnumerable<Users> GetUsers();

        // students
        public Student AddStudent(Student student);
        public void DeleteStudent(int studentId);
        public Student UpdateStudent(Student student);
        public Student? GetStudent(int studentId);
        public IEnumerable<Student> GetStudents();

        // professors
        public Professor AddProfessor(Professor professor);
        public void DeleteProfessor(int professorId);
        public Professor UpdateProfessor(Professor professor);
        public Professor? GetProfessor(int professorId);
        public IEnumerable<Professor> GetProfessors();

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
        public IEnumerable<SemesterRegistration> GetSemesterRegistrations();

        // logs
        public void AddErrorLog(ApiErrorLog log);
        public void AddErrorLog(DbErrorLog log);
    }
}
