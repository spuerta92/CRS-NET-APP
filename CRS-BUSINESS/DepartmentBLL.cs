using CRS_DAO;
using CRS_MODELS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class DepartmentBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<DepartmentBLL> logger;

        public DepartmentBLL(ILogger<DepartmentBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<Departments> GetDepartments()
        {
            var departments = repository.GetDepartments();
            return departments;
        }

        public Departments GetDepartment(int departmentId)
        {
            var department = repository.GetDepartment(departmentId);
            return department;
        }

        public Departments AddDepartment(Departments department)
        {
            var newDepartment = repository.AddDepartment(department);
            return newDepartment;
        }

        public Departments UpdateDepartment(Departments department)
        {
            var existingDepartment = repository.UpdateDepartment(department);
            return existingDepartment;
        }

        public void DeleteDepartment(int departmentId)
        {
            repository.DeleteDepartment(departmentId);
        }
    }
}
