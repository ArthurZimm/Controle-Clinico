using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IPatientRepository : IAsynRepository<Patient>
    {
        Task<(bool result, string message, Patient response)> GetPatientByName(string patientName);
    }
}