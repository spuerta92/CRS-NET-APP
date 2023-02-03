using CRS_DAO;
using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_BUSINESS
{
    /// <summary>
    /// Professor business logic layer
    /// </summary>
    public class ProfessorBLL
    {
        private readonly ICrsRepository repository;

        public ProfessorBLL(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Professors> GetProfessors()
        {
            var professors = repository.GetProfessors();
            return professors;
        }

        public Professors GetProfessor(int professorId)
        {
            var professor = repository.GetProfessor(professorId);
            return professor;
        }

        public Professors AddProfessor(Professors professor)
        {
            var newProfessor = repository.AddProfessor(professor);
            return newProfessor;
        }

        public Professors UpdateProfessor(Professors professor)
        {
            var existingProfessor = repository.UpdateProfessor(professor);
            return existingProfessor;
        }

        public void DeleteProfessor(int professorId)
        {
            repository.DeleteProfessor(professorId);
        }
    }
}
