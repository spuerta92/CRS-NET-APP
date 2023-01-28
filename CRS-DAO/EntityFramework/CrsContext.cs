using CRS_MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO.EntityFramework
{
    public class CrsContext : DbContext
    {
        public CrsContext(DbContextOptions<CrsContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCatalog> CourseCatalog { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProfessorCourses> ProfessorCourses { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
        public DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SemesterRegistration> SemesterRegistration { get; set; }
        public DbSet<ApiErrorLog> ApiServiceLogs { get; set; }
        public DbSet<DbErrorLog> DatabaseLogs { get; set; }

    }
}
