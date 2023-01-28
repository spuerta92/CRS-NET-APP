using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    [Table("Professors")]
    public class Professors
    {
        [Key]
        public int ProfessorId { get; set; }
        public string ProfessorName { get; set; }
        [ForeignKey("FK_Professors_DepartmentId")]
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [ForeignKey("FK_Professors_UserId")]
        public int UserId { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
