using CRS_DAO;
using CRS_MODELS;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RoleBLL> logger;

        public RoleBLL(ILogger<RoleBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<Roles> GetRoles()
        {
            var roles = repository.GetRoles();
            return roles;
        }

        public Roles GetRole(int roleId)
        {
            var role = repository.GetRole(roleId);
            return role;
        }

        public Roles AddRole(Roles role)
        {
            var newRole = repository.AddRole(role);
            return newRole;
        }

        public Roles UpdateRole(Roles role)
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
