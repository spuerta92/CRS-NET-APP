using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    public class RegistrationStatusBLL
    {
        private readonly ICrsRepository repository;

        public RegistrationStatusBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<RegistrationStatus> GetRegistrationStatuss()
        {
            var registrationStatuses = repository.GetRegistrationStatuses();
            return registrationStatuses;
        }

        public RegistrationStatus GetRegistrationStatus(int registrationStatusId)
        {
            var registrationStatus = repository.GetRegistrationStatus(registrationStatusId);
            return registrationStatus;
        }

        public RegistrationStatus AddRegistrationStatus(RegistrationStatus registrationStatus)
        {
            var newRegistrationStatus = repository.AddRegistrationStatus(registrationStatus);
            return newRegistrationStatus;
        }

        public RegistrationStatus UpdateRegistrationStatus(RegistrationStatus registrationStatus)
        {
            var existingRegistrationStatus = repository.UpdateRegistrationStatus(registrationStatus);
            return existingRegistrationStatus;
        }

        public void DeleteRegistrationStatus(int registrationStatusId)
        {
            repository.DeleteRegistrationStatus(registrationStatusId);
        }
    }
}
