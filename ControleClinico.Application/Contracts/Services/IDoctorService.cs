using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IDoctorService : IAsyncServices<DoctorRequest, DoctorResponse>
    {
    }
}