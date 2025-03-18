using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IDoctorService
    {
        Task<(bool, string, DoctorResponse?)> GetDoctorByCrm(string crm);
        Task<(bool, string, List<DoctorResponse>?)> GetAllDoctors();
        Task<(bool, string, DoctorResponse?)> AddDoctor(DoctorRequest doctor);
        Task<(bool, string, DoctorResponse?)> UpdateDoctor(DoctorRequest doctor);
        Task<(bool, string)> DeleteDoctor(DoctorRequest doctor);
    }
}