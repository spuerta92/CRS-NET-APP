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
        public DbSet<Students> Students { get; set; }
        public DbSet<Professors> Professors { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseCatalog> CourseCatalog { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<ProfessorCourses> ProfessorCourses { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
        public DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SemesterRegistration> SemesterRegistration { get; set; }
        public DbSet<ApiErrorLog> ApiServiceLogs { get; set; }
        public DbSet<DbErrorLog> DatabaseLogs { get; set; }

    }
}
