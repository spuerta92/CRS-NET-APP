using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Role(int roleId, string roleName, string description, string uUID, DateTime createDateTime)
        {
            RoleId = roleId;
            RoleName = roleName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
