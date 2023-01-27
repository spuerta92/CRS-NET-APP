using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class RegistrationStatus
    {
        [Key]
        public int RegistrationStatusId { get; set; }
        public string RegistrationStatusName { get; set; }
        public string Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public RegistrationStatus(int registrationStatusId, string registrationStatusName, string description, string uUID, DateTime createDateTime)
        {
            RegistrationStatusId = registrationStatusId;
            RegistrationStatusName = registrationStatusName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
