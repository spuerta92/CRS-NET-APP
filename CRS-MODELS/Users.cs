using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("FK_Users_RoleId")]
        public int RoleId { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
