using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IConsultationService : IAsyncServices<ConsultationRequest, ConsultationResponse>
    {
        Task<(bool result, string message, ConsultationResponse response)> GetConsultationById(int id);
    }
}