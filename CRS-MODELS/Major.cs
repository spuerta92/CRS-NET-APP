using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        public int MajorName { get; set; }
        public int Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Major(int majorId, int majorName, int description, string uUID, DateTime createDateTime)
        {
            MajorId = majorId;
            MajorName = majorName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
