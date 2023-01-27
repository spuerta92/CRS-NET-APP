using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.StudentDtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int UserId { get; set; }
        public int MajorId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
