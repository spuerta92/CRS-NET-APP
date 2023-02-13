using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CRS_MODELS
{
    [Table("CourseCatalog")]
    public class CourseCatalog
    {
        [Key]
        public int CourseCatalogId { get; set; }
        [ForeignKey("FK_CourseCatalog_CourseId")]
        public int CourseId { get; set; }
        [ForeignKey("FK_CourseCatalog_ProfessorId")]
        public int ProfessorId { get; set; }
        [ForeignKey("FK_CourseCatalog_DepartmentId")]
        public int DepartmentId { get; set; }
        public string? Prerequisite { get; set; }
        public int Credits { get; set; }
        public int Capacity { get; set; }
        public int? Enrolled { get; set; }
        public string Semester { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
