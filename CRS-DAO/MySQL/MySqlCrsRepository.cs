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

        public Course AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog AddCourseToCourseCatalog(CourseCatalog course)
        {
            throw new NotImplementedException();
        }

        public Department AddDepartment(Department deparment)
        {
            throw new NotImplementedException();
        }

        public Major AddMajor(Major major)
        {
            throw new NotImplementedException();
        }

        public Payment AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod AddPaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Professor AddProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }

        public RegistrationStatus AddRegistrationStatus(RegistrationStatus registrationStatus)
        {
            throw new NotImplementedException();
        }

        public Role AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration AddSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            throw new NotImplementedException();
        }

        public Student AddStudent(Student student)
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

        public IEnumerable<Professor> GetAdmins()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseCatalog> GetAllCoursesFromCourseCatalog()
        {
            throw new NotImplementedException();
        }

        public Course GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog GetCourseFromCourseCatalog(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public Department GetDepartment(int deparmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Major GetMajor(int majorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Major> GetMajors()
        {
            throw new NotImplementedException();
        }

        public Payment GetPayment(int paymentId)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetPaymentMethod(int paymentMethodId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

        public Professor GetProfessor(int professorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professor> GetProfessors()
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

        public Role GetRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetRoles()
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

        public Student GetStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
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

        public Course UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog UpdateCourseInCourseCatalog(CourseCatalog course)
        {
            throw new NotImplementedException();
        }

        public Department UpdateDepartment(Department deparment)
        {
            throw new NotImplementedException();
        }

        public Major UpdateMajor(Major major)
        {
            throw new NotImplementedException();
        }

        public Payment UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Professor UpdateProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }

        public RegistrationStatus UpdateRegistrationStatus(RegistrationStatus registrationStatus)
        {
            throw new NotImplementedException();
        }

        public Role UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public SemesterRegistration UpdateSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(Student student)
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
    }
}
