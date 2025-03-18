using AutoMapper;
using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            this.mapper = mapper;
        }
        public async Task<(bool, string, List<DoctorResponse>?)> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            if (doctors.Item1)
            {
                return (true, string.Empty, mapper.Map<List<DoctorResponse>>(doctors.Item3));
            }
            return (false, "error when searching for doctors", null);
        }

        public async Task<(bool, string, DoctorResponse?)> GetDoctorByCrm(string crm)
        {
            var doctor = await _doctorRepository.GetDoctorByCrm(crm);
            if (doctor.Item1)
            {
                return (true, string.Empty, mapper.Map<DoctorResponse>(doctor.Item3));
            }
            return (false, "error when searching for doctor", null);
        }
        public async Task<(bool, string, DoctorResponse?)> AddDoctor(DoctorRequest doctor)
        {
            var doctorResponse = await _doctorRepository.AddDoctor(mapper.Map<Doctor>(doctor));
            if (doctorResponse.Item1)
            {
                return (true, string.Empty, mapper.Map<DoctorResponse>(doctorResponse.Item3));
            }
            return (false, "error when adding doctor", null);
        }
        public async Task<(bool, string, DoctorResponse?)> UpdateDoctor(DoctorRequest doctor)
        {
            var doctorResponse = await _doctorRepository.UpdateDoctor(mapper.Map<Doctor>(doctor));
            if (doctorResponse.Item1)
            {
                return (true, string.Empty, mapper.Map<DoctorResponse>(doctorResponse.Item3));
            }
            return (false, "error when updating doctor", null);
        }
        public async Task<(bool, string)> DeleteDoctor(DoctorRequest doctor)
        {
            var doctorResponse = await _doctorRepository.DeleteDoctor(mapper.Map<Doctor>(doctor));
            if (doctorResponse.Item1)
            {
                return (true, string.Empty);
            }
            return (false, "error when deleting doctor");
        }
    }
}