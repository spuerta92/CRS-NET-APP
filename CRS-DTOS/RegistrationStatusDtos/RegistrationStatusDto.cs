using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.RegistrationStatusDtos
{
    public class RegistrationStatusDto
    {
        public int RegistrationStatusId { get; set; }
        public string RegistrationStatusName { get; set; }
        public string Description { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
