using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.ProfessorDtos
{
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string ProfessorName { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
