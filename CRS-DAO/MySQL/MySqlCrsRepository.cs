using CRS_MODELS;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO.MySQL
{
    public class MySqlCrsRepository : ICrsRepository
    {
        private MySqlConnection connection;

        public MySqlCrsRepository() 
        { 
            connection = new MySqlConnection(DbSettings.MYSQLConnectionString);
        }

        public Admin AddAdmin(Admin admin)
        {
            Admin? item = null;

            try
            {
                using (connection)
                {
                    connection.Open();

                    // add admin
                    using (MySqlCommand command = new MySqlCommand(Constants.AddAdmin(admin), connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // get admin
                    using (MySqlCommand command = new MySqlCommand(Constants.GetLastAdmin(), connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            var parser = reader.GetRowParser<Admin>(typeof(Admin));
                            while (reader.Read())
                            {
                                item = parser(reader);
                            }

                            return item;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Courses AddCourse(Courses course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalogs AddCourseToCourseCatalog(CourseCatalogs course)
        {
            throw new NotImplementedException();
        }

        public Departments AddDepartment(Departments deparment)
        {
            throw new NotImplementedException();
        }

        public Majors AddMajor(Majors major)
        {
            throw new NotImplementedException();
        }

        public Payment AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public PaymentMethods AddPaymentMethod(PaymentMethods paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Professors AddProfessor(Professors professor)
        {
            throw new NotImplementedException();
        }

        public RegistrationStatus AddRegistrationStatus(RegistrationStatus registrationStatus)
        {
            throw new NotImplementedException();
        }

        public Roles AddRole(Roles role)
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration AddSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            throw new NotImplementedException();
        }

        public Students AddStudent(Students student)
        {
            throw new NotImplementedException();
        }

        public Users AddUser(Users user)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourseFromCourseCatalog(int courseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMajor(int majorId)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int paymentId)
        {
            throw new NotImplementedException();
        }

        public void DeletePaymentMethod(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProfessor(int professorId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegistrationStatus(int registrationStatusId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSemesterRegistration(int semesterRegistrationId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professors> GetAdmins()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseCatalogs> GetAllCoursesFromCourseCatalog()
        {
            throw new NotImplementedException();
        }

        public Courses GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public CourseCatalogs GetCourseFromCourseCatalog(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Departments GetDepartment(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departments> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Majors GetMajor(int majorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Majors> GetMajors()
        {
            throw new NotImplementedException();
        }

        public Payment GetPayment(int paymentId)
        {
            throw new NotImplementedException();
        }

        public PaymentMethods GetPaymentMethod(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentMethods> GetPaymentMethods()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

        public Professors GetProfessor(int professorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professors> GetProfessors()
        {
            throw new NotImplementedException();
        }

        public RegistrationStatus GetRegistrationStatus(int registrationStatusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegistrationStatus> GetRegistrationStatuses()
        {
            throw new NotImplementedException();
        }

        public Roles GetRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> GetRoles()
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration GetSemesterRegistration(int semesterRegistrationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SemesterRegistration> GetSemesterRegistrations()
        {
            throw new NotImplementedException();
        }

        public void AddErrorLog(ApiErrorLog log)
        {
            throw new NotImplementedException();
        }

        public void AddErrorLog(DbErrorLog log)
        {
            throw new NotImplementedException();
        }

        public Students GetStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Students> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Users GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Users? GetUser(string userName, string password, int roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Admin UpdateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Courses UpdateCourse(Courses course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalogs UpdateCourseInCourseCatalog(CourseCatalogs course)
        {
            throw new NotImplementedException();
        }

        public Departments UpdateDepartment(Departments deparment)
        {
            throw new NotImplementedException();
        }

        public Majors UpdateMajor(Majors major)
        {
            throw new NotImplementedException();
        }

        public Payment UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public PaymentMethods UpdatePaymentMethod(PaymentMethods paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Professors UpdateProfessor(Professors professor)
        {
            throw new NotImplementedException();
        }

        public RegistrationStatus UpdateRegistrationStatus(RegistrationStatus registrationStatus)
        {
            throw new NotImplementedException();
        }

        public Roles UpdateRole(Roles role)
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration UpdateSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            throw new NotImplementedException();
        }

        public Students UpdateStudent(Students student)
        {
            throw new NotImplementedException();
        }

        public Users UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Admin> ICrsRepository.GetAdmins()
        {
            throw new NotImplementedException();
        }

        public ProfessorCourses AddProfessorCourses(ProfessorCourses professorCourse)
        {
            throw new NotImplementedException();
        }

        public void DeleteProfessorCourses(int professorCourseId)
        {
            throw new NotImplementedException();
        }

        public ProfessorCourses UpdateProfessorCourses(ProfessorCourses professorCourse)
        {
            throw new NotImplementedException();
        }

        public ProfessorCourses? GetProfessorCourse(int professorCourseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfessorCourses> GetProfessorCourses()
        {
            throw new NotImplementedException();
        }

        public RegisteredCourse AddRegisteredCourse(RegisteredCourse registeredCourse)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegisteredCourse(int registeredCourseId)
        {
            throw new NotImplementedException();
        }

        public RegisteredCourse UpdateRegisteredCourse(RegisteredCourse registeredCourse)
        {
            throw new NotImplementedException();
        }

        public RegisteredCourse? GetRegisteredCourse(int registeredCourseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredCourse> GetRegisteredCourses()
        {
            throw new NotImplementedException();
        }

        public RegisteredCourse RegisterForCourse(RegisteredCourse registeredCourse)
        {
            throw new NotImplementedException();
        }

        public Students? GetStudentByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration? GetSemesterRegistrationByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public RegisteredCourse? GetRegisteredCourseByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
