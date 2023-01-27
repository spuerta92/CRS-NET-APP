using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.RegistrationStatusDtos
{
    public class AddRegistrationStatusDto
    {
        [Required]
        public string RegistrationStatusName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
