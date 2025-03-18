using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IPatientService
    {
        Task<(bool, string, List<PatientResponse>?)> GetAllPatients();
        Task<(bool, string, PatientResponse?)> GetPatientByCpf(string cpf);
        Task<(bool, string, PatientResponse?)> GetPatientByName(string name);
        Task<(bool, string, PatientResponse?)> AddPatient(PatientRequest patient);
        Task<(bool, string, PatientResponse?)> UpdatePatient(PatientRequest patient);
        Task<(bool, string)> DeletePatient(PatientRequest patient);
    }
}