using CRS_MODELS;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO.MongoDB
{
    public class MongoCrsRepository : ICrsRepository
    {
        private const string databaseName = "CRS";

        private const string usersCollectionName = "Users";
        private const string studentsCollectionName = "Students";
        private const string professorsCollectionName = "Professors";
        private const string adminCollectionName = "Admin";

        private readonly IMongoCollection<Users> usersCollection;
        private readonly IMongoCollection<Student> studentsCollection;
        private readonly IMongoCollection<Professor> professorsCollection;
        private readonly IMongoCollection<Admin> adminCollection;

        private readonly FilterDefinitionBuilder<Users> userFilterBuilder = Builders<Users>.Filter;
        private readonly FilterDefinitionBuilder<Student> studentFilterBuilder = Builders<Student>.Filter;
        private readonly FilterDefinitionBuilder<Professor> professorFilterBuilder = Builders<Professor>.Filter;
        private readonly FilterDefinitionBuilder<Admin> adminFilterBuilder = Builders<Admin>.Filter;

        public MongoCrsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);

            usersCollection = database.GetCollection<Users>(usersCollectionName);
            studentsCollection = database.GetCollection<Student>(studentsCollectionName);
            professorsCollection = database.GetCollection<Professor>(professorsCollectionName);
            adminCollection = database.GetCollection<Admin>(adminCollectionName);
        }

        public Admin AddAdmin(Admin admin)
        {
            // check below all admin CRUD operations have been added.

            adminCollection.InsertOne(admin);

            var filter = adminFilterBuilder.Eq(admin => admin.AdminId, admin.AdminId);

            return adminCollection.Find(filter).SingleOrDefault();
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
            var filter = adminFilterBuilder.Eq(admin => admin.AdminId, adminId);
            adminCollection.DeleteOne(filter);
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
            var filter = adminFilterBuilder.Eq(admin => admin.AdminId, adminId);
            return adminCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return adminCollection.Find(new BsonDocument()).ToList();
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
            var filter = adminFilterBuilder.Eq(x => x.AdminId, admin.AdminId);
            adminCollection.ReplaceOne(filter, admin);

            filter = adminFilterBuilder.Eq(x => x.AdminId, admin.AdminId);
            return adminCollection.Find(filter).SingleOrDefault();
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
