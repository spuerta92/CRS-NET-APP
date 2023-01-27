using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class SemesterRegistration
    {
        public SemesterRegistration(int registrationId, int studentId, int approvalStatus, int adminId, string comment, string uUID, DateTime createDateTime)
        {
            RegistrationId = registrationId;
            StudentId = studentId;
            ApprovalStatus = approvalStatus;
            AdminId = adminId;
            Comment = comment;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }

        [Key]
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int ApprovalStatus { get; set; }
        public int AdminId { get; set; }
        public string Comment { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
