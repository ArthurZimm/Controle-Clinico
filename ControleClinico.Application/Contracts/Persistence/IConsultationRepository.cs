using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IConsultationRepository
    {
        Task<(bool, string, List<Consultation>?)> GetConsultationsByPatientCpf(string patientCpf);
        Task<(bool, string, List<Consultation>?)> GetConsultationsByDoctorCrm(string doctorCrm);
        Task<(bool, string, Consultation?)> GetConsultationById(Guid id);
        Task<(bool, string, Consultation?)> AddConsultation(Consultation consultation);
        Task<(bool, string, Consultation?)> UpdateConsultation(Consultation consultation);
        Task<(bool, string)> DeleteConsultation(Consultation consultation);
    }
}