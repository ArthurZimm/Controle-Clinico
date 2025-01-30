using AutoMapper;
using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IAsyncRepository<Consultation> _consultationRepository;
        private readonly IAsyncRepository<Doctor> _doctorRepository;
        private readonly IAsyncRepository<Patient> _patientRepository;
        private readonly IMapper mapper;

        public ConsultationService(IAsyncRepository<Consultation> consultationRepository, IAsyncRepository<Doctor> doctorRepository, 
                                    IAsyncRepository<Patient> patientRepository, IMapper mapper)
        {
            _consultationRepository = consultationRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            this.mapper = mapper;
        }

        public async Task<(bool result, string message, IReadOnlyList<ConsultationResponse>? response)> GetAllAsync()
        {
            try
            {
                var consultations = await _consultationRepository.GetAllAsync();
                if (consultations == null)
                {
                    return (false, "Sem Consultas", null);
                }
                return (true, string.Empty, mapper.Map<IReadOnlyList<ConsultationResponse>?>(consultations)) ;
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message, ConsultationResponse? response)> GetConsultationById(int id)
        {
            try
            {
                var consultation = await _consultationRepository.GetByIdAsync(id);
                if (consultation == null)
                {
                    return (false, "Sem Consultas", null);
                }
                return (true, string.Empty, mapper.Map<ConsultationResponse?>(consultation));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message, ConsultationResponse? response)> AddAsync(ConsultationRequest entity)
        {
            entity.Doctor = await _doctorRepository.GetByNameAsync(entity.DoctorName);
            if(entity.Doctor == null)
                return (false, "Médico não encontrado", null);
            entity.Patient = await _patientRepository.GetByNameAsync(entity.PatientName);
            if(entity.Patient == null)
                return (false, "Paciente não encontrado", null);
            if(!await VerifyDoctorCalendar(entity.DoctorName, entity.Date))
                return (false, "Médico já possui consulta nesse horário", null);
            try
            {
                var newConsultation = await _consultationRepository.AddAsync(mapper.Map<Consultation>(entity));
                if(newConsultation == null)
                {
                    return (false, "Erro ao adicionar consulta", null);
                }
                return (true, string.Empty, mapper.Map<ConsultationResponse>(newConsultation));
            }
            catch (Exception ex)
            {
             return (false, ex.Message, null);
            }
        }
        public async Task<(bool result, string message, ConsultationResponse? response)> UpdateAsync(ConsultationRequest entity)
        {
            try
            {
                var consultation = await _consultationRepository.UpdateAsync(mapper.Map<Consultation>(entity));
                if (consultation == null)
                {
                    return (false, "Erro ao atualizar consulta", null);
                }
                return (true, string.Empty, mapper.Map<ConsultationResponse>(consultation));
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message)> DeleteAsync(int id)
        {
            try
            {
                var consultation = await _consultationRepository.GetByIdAsync(id);
                if (consultation == null)
                {
                    return (false, "Consulta não encontrada");
                }
                await _consultationRepository.DeleteAsync(consultation);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<bool> VerifyDoctorCalendar(string name, DateTime consultationDate)
        {
            var doctor = await _doctorRepository.GetByNameAsync(name);
            if(doctor.Consultations.First(t => t.Date == consultationDate) != null)
                return false;
            return true;
        }
    }
}