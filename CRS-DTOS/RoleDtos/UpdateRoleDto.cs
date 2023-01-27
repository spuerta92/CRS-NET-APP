using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.RoleDtos
{
    public class UpdateRoleDto
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
