﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DTOS.RegisteredCourseDtos
{
    public class RegisteredCourseDto
    {
        public int RegisteredCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int RegistrationStatusId { get; set; }
        public string? Grade { get; set; }
        public string? UUID { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
