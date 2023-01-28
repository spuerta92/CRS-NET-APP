using CRS_DAO;
using CRS_MODELS;
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

        public DepartmentBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var departments = repository.GetDepartments();
            return departments;
        }

        public Department GetDepartment(int departmentId)
        {
            var department = repository.GetDepartment(departmentId);
            return department;
        }

        public Department AddDepartment(Department department)
        {
            var newDepartment = repository.AddDepartment(department);
            return newDepartment;
        }

        public Department UpdateDepartment(Department department)
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
