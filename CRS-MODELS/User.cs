using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public User(int userId, string userName, string password, int roleId, string uUID, DateTime createDateTime)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            RoleId = roleId;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
