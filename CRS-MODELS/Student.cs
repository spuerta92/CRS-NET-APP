using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int UserId { get; set; }
        public int MajorId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Student(int studentId, string studentName, int userId, int majorId, string email, string phone, string address, string uUID, DateTime createDateTime)
        {
            StudentId = studentId;
            StudentName = studentName;
            UserId = userId;
            MajorId = majorId;
            Email = email;
            Phone = phone;
            Address = address;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
