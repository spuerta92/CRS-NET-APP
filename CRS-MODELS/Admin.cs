using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Admin(int adminId, string adminName, string email, string phone, string address, int userId, string uUID, DateTime createDateTime)
        {
            AdminId = adminId;
            AdminName = adminName;
            Email = email;
            Phone = phone;
            Address = address;
            UserId = userId;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
