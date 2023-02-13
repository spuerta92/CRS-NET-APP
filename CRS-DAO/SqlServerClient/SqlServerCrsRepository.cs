using System.Data;
using CRS_MODELS;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CRS_DAO.SqlServerClient
{
    public class SqlServerCrsRepository : ICrsRepository
    {
        private SqlConnection connection;

        private readonly string connectionString =
            "Server=(LocalDb)\\MSSQLLocalDB; Database=CRS; Integrated Security=True";

        public SqlServerCrsRepository()
        {
        }
        public Admin AddAdmin(Admin admin)
        {
            Admin? item = null;
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    if (connection == null || connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // add admin
                    using (SqlCommand command = new SqlCommand(Constants.AddAdmin(admin), connection))
                    { 
                        command.ExecuteNonQuery();
                    }

                    // get admin
                    using (SqlCommand command = new SqlCommand(Constants.GetLastAdmin(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
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
            catch(Exception ex) 
            { 
                throw;  
            }
        }

        public Courses AddCourse(Courses course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog AddCourseToCourseCatalog(CourseCatalog course)
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

        public IEnumerable<CourseCatalog> GetAllCoursesFromCourseCatalog()
        {
            throw new NotImplementedException();
        }

        public Courses GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog GetCourseFromCourseCatalog(int courseId)
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

        public Users? GetUser(int userId)
        {
            Users? item = null;
            connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    if (connection == null || connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // get users
                    using (SqlCommand command = new SqlCommand(Constants.GetUserById(userId), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var parser = reader.GetRowParser<Users>(typeof(Users));
                            while (reader.Read())
                            {
                                item = parser(reader);
                            }

                            connection.Close();
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

        public Users? GetUser(string userName, string password, int roleId)
        {
            Users? item = null;
            connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    if (connection == null || connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // get users
                    using (SqlCommand command = new SqlCommand(Constants.GetUser(userName, password, roleId), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var parser = reader.GetRowParser<Users>(typeof(Users));
                            while (reader.Read())
                            {
                                item = parser(reader);
                            }

                            connection.Close();
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

        public Users? GetLastUser()
        {
            Users? item = null;
            connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    if (connection == null || connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // get users
                    using (SqlCommand command = new SqlCommand(Constants.GetLastUser(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var parser = reader.GetRowParser<Users>(typeof(Users));
                            while (reader.Read())
                            {
                                item = parser(reader);
                            }

                            connection.Close();
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

        public IEnumerable<Users> GetUsers()
        {
            var items = new List<Users>();
            connection = new SqlConnection(connectionString);


            try
            {
                using (connection)
                {
                    if (connection == null || connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // get users
                    using (SqlCommand command = new SqlCommand(Constants.GetAllUsers(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var parser = reader.GetRowParser<Users>(typeof(Users));
                            while (reader.Read())
                            {
                                var item = parser(reader);
                                items.Add(item);
                            }

                            return items;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Admin UpdateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Courses UpdateCourse(Courses course)
        {
            throw new NotImplementedException();
        }

        public CourseCatalog UpdateCourseInCourseCatalog(CourseCatalog course)
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

        public IEnumerable<Grades> ViewGrades(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetStudentCourses(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetStudentRegisteredCourses(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Courses> GetRegisteredCoursesOnlyCourses()
        {
            throw new NotImplementedException();
        }
    }
}
