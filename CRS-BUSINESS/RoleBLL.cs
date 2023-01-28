using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class RoleBLL
    {
        private readonly ICrsRepository repository;

        public RoleBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Role> GetRoles()
        {
            var roles = repository.GetRoles();
            return roles;
        }

        public Role GetRole(int roleId)
        {
            var role = repository.GetRole(roleId);
            return role;
        }

        public Role AddRole(Role role)
        {
            var newRole = repository.AddRole(role);
            return newRole;
        }

        public Role UpdateRole(Role role)
        {
            var existingRole = repository.UpdateRole(role);
            return existingRole;
        }

        public void DeleteRole(int roleId)
        {
            repository.DeleteRole(roleId);
        }
    }
}
