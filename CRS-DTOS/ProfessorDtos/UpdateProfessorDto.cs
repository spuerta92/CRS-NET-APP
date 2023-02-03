using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.ProfessorDtos
{
    public class UpdateProfessorDto
    {
        [Required]
        public string ProfessorName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
