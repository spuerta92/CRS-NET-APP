using CRS_DAO;
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

        public IEnumerable<Admin> GetAdmins()
        {
            var admins = repository.GetAdmins();
            return admins;
        }

        public Admin GetAdmin(int adminId)
        {
            var admin = repository.GetAdmin(adminId);
            return admin;
        }

        public Admin AddAdmin(Admin admin)
        {
            var newAdmin = repository.AddAdmin(admin);
            return newAdmin;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            var existingAdmin = repository.UpdateAdmin(admin);
            return existingAdmin;
        }

        public void DeleteAdmin(int adminId)
        {
            repository.DeleteAdmin(adminId);
        }
    }
}