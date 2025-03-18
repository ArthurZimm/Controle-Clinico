using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IPatientRepository
    {
        Task<(bool, string, List<Patient>?)> GetAllPatients();
        Task<(bool, string, Patient?)> GetPatientByCpf(string cpf);
        Task<(bool, string, Patient?)> GetPatientByName(string name);
        Task<(bool, string, Patient?)> AddPatient(Patient patient);
        Task<(bool, string, Patient?)> UpdatePatient(Patient patient);
        Task<(bool,string)> DeletePatient(Patient patient);
    }
}