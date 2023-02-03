using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.MajorDtos
{
    public class MajorDto
    {
        public int MajorId { get; set; }
        public int MajorName { get; set; }
        public int Description { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
