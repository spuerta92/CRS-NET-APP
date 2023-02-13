using CRS_DAO;
using CRS_EXCEPTIONS;
using CRS_MODELS;

namespace CRS_BUSINESS
{
    /// <summary>
    /// Admin business logic layer
    /// </summary>
    public class AdminBLL
    {
        private readonly ICrsRepository repository;

        public AdminBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets a list of admins
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<Admin> GetAdmins()
        {
            try
            {
                var admins = repository.GetAdmins();
                return admins;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets an admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Admin GetAdmin(int adminId)
        {
            try
            {
                var admin = repository.GetAdmin(adminId);
                return admin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add a new admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Admin AddAdmin(Admin admin)
        {
            try
            {
                var newAdmin = repository.AddAdmin(admin);
                return newAdmin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates a specific admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Admin UpdateAdmin(Admin admin)
        {
            try
            {
                var existingAdmin = repository.UpdateAdmin(admin);
                return existingAdmin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteAdmin(int adminId)
        {
            try
            {
                repository.DeleteAdmin(adminId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create a payment record for a specific student
        /// </summary>
        /// <param name="payment"></param>
        /// <exception cref="Exception"></exception>
        public void CreatePaymentBill(Payment payment)
        {
            try
            {
                repository.AddPayment(payment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create semester registration for a specific student
        /// </summary>
        /// <param name="registration"></param>
        /// <exception cref="Exception"></exception>
        public SemesterRegistration CreateStudentSemesterRegistration(SemesterRegistration registration)
        {
            try
            {
                var student = repository.GetStudent(registration.StudentId);
                if (student == null)
                {
                    throw new StudentNotFoundException("Student does not exist");
                }

                var user = repository.GetUser(student.UserId);
                if (user == null)
                {
                    throw new UserNotFoundException("User does not exist");
                }

                var existingRegistration = repository.GetSemesterRegistration(registration.StudentId);
                if (existingRegistration != null)
                {
                    throw new DuplicateSemesterRegistrationException(
                        "Semester registration already exists for this specific student");
                }

                return repository.AddSemesterRegistration(registration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update student semester registration
        /// </summary>
        /// <param name="registration"></param>
        /// <exception cref="StudentNotFoundException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="DuplicateSemesterRegistrationException"></exception>
        /// <exception cref="Exception"></exception>
        public void UpdateStudentSemesterRegistration(SemesterRegistration registration)
        {
            try
            {
                var student = repository.GetStudent(registration.StudentId);
                if (student == null)
                {
                    throw new StudentNotFoundException("Student does not exist");
                }

                var user = repository.GetUser(student.UserId);
                if (user == null)
                {
                    throw new UserNotFoundException("User does not exist");
                }

                var existingRegistration = repository.GetSemesterRegistration(registration.StudentId);
                if (existingRegistration != null)
                {
                    throw new DuplicateSemesterRegistrationException(
                        "Semester registration already exists for this specific student");
                }

                repository.UpdateSemesterRegistration(registration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SemesterRegistration? GetStudentSemesterRegistration(int studentId)
        {
            try
            {
                var student = repository.GetStudent(studentId);
                if (student == null)
                {
                    throw new StudentNotFoundException("Student does not exist");
                }

                var user = repository.GetUser(student.UserId);
                if (user == null)
                {
                    throw new UserNotFoundException("User does not exist");
                }

                return repository.GetSemesterRegistration(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}