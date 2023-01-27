using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string UUID { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Department(int departmentId, string departmentName, string description, string uUID, DateTime createDateTime)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            Description = description;
            UUID = uUID;
            CreateDateTime = createDateTime;
        }
    }
}
