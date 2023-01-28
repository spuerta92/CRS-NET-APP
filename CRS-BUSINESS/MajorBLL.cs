using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class MajorBLL
    {
        private readonly ICrsRepository repository;

        public MajorBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Major> GetMajors()
        {
            var majors = repository.GetMajors();
            return majors;
        }

        public Major GetMajor(int majorId)
        {
            var major = repository.GetMajor(majorId);
            return major;
        }

        public Major AddMajor(Major major)
        {
            var newMajor = repository.AddMajor(major);
            return newMajor;
        }

        public Major UpdateMajor(Major major)
        {
            var existingMajor = repository.UpdateMajor(major);
            return existingMajor;
        }

        public void DeleteMajor(int majorId)
        {
            repository.DeleteMajor(majorId);
        }
    }
}
