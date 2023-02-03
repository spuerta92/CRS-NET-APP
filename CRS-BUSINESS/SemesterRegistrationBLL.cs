using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class SemesterRegistrationBLL
    {
        private readonly ICrsRepository repository;

        public SemesterRegistrationBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SemesterRegistration> GetSemesterRegistrations()
        {
            var semesterRegistrations = repository.GetSemesterRegistrations();
            return semesterRegistrations;
        }

        public SemesterRegistration GetSemesterRegistration(int semesterRegistrationId)
        {
            var semesterRegistration = repository.GetSemesterRegistration(semesterRegistrationId);
            return semesterRegistration;
        }

        public SemesterRegistration AddSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            var newSemesterRegistration = repository.AddSemesterRegistration(semesterRegistration);
            return newSemesterRegistration;
        }

        public SemesterRegistration UpdateSemesterRegistration(SemesterRegistration semesterRegistration)
        {
            var existingSemesterRegistration = repository.UpdateSemesterRegistration(semesterRegistration);
            return existingSemesterRegistration;
        }

        public void DeleteSemesterRegistration(int semesterRegistrationId)
        {
            repository.DeleteSemesterRegistration(semesterRegistrationId);
        }
    }
}
