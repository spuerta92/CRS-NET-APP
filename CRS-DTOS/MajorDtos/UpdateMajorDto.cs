using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.MajorDtos
{
    public class UpdateMajorDto
    {
        [Required]
        public int MajorName { get; set; }
        [Required]
        public int Description { get; set; }
    }
}
