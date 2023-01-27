using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.DepartmentDtos
{
    public class AddDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
