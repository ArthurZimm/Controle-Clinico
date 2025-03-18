using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IDoctorRepository
    {
        Task<(bool, string, Doctor?)> GetDoctorByCrm(string crm);
        Task<(bool, string, List<Doctor>?)> GetAllDoctors();
        Task<(bool, string, Doctor?)> AddDoctor(Doctor doctor);
        Task<(bool, string, Doctor?)> UpdateDoctor(Doctor doctor);
        Task<(bool, string)> DeleteDoctor(Doctor doctor);
    }
}