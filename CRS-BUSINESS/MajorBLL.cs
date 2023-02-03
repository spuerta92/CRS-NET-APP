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
    public class MajorBLL
    {
        private readonly ICrsRepository repository;
        private readonly ILogger<MajorBLL> logger;

        public MajorBLL(ILogger<MajorBLL> logger, ICrsRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<Majors> GetMajors()
        {
            var majors = repository.GetMajors();
            return majors;
        }

        public Majors GetMajor(int majorId)
        {
            var major = repository.GetMajor(majorId);
            return major;
        }

        public Majors AddMajor(Majors major)
        {
            var newMajor = repository.AddMajor(major);
            return newMajor;
        }

        public Majors UpdateMajor(Majors major)
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
