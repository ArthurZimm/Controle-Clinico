using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IConsultationService
    {
        Task<(bool, string, List<ConsultationResponse>?)> GetConsultationsByPatientCpf(string patientCpf);
        Task<(bool, string, List<ConsultationResponse>?)> GetConsultationsByDoctorCrm(string doctorCrm);
        Task<(bool, string, ConsultationResponse?)> GetConsultationById(Guid id);
        Task<(bool, string, ConsultationResponse?)> AddConsultation(AppointmentRequest appointmentRequest);
        Task<(bool, string, ConsultationResponse?)> UpdateConsultation(ConsultationRequest consultation);
        Task<(bool, string)> DeleteConsultation(ConsultationRequest consultation);
    }
}