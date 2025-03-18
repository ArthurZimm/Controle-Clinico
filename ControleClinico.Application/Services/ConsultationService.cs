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
        private readonly IConsultationRepository _consultationRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public ConsultationService(IConsultationRepository consultationRepository, IDoctorRepository doctorRepository, 
            IPatientRepository patientRepository, IMapper mapper)
        {
            _consultationRepository = consultationRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<(bool, string, ConsultationResponse?)> GetConsultationById(Guid id)
        {
            var consultation = await _consultationRepository.GetConsultationById(id);
            if (consultation.Item1)
            {
                return (true, string.Empty, _mapper.Map<ConsultationResponse>(consultation.Item3));
            }
            return (false, "Consultation not found", null);
        }

        public async Task<(bool, string, List<ConsultationResponse>?)> GetConsultationsByDoctorCrm(string doctorCrm)
        {
            var consultations = await _consultationRepository.GetConsultationsByDoctorCrm(doctorCrm);
            if (consultations.Item1)
            {
                return (true, string.Empty, _mapper.Map<List<ConsultationResponse>>(consultations.Item3));
            }
            return (false, "Consultations not found", null);
        }

        public async Task<(bool, string, List<ConsultationResponse>?)> GetConsultationsByPatientCpf(string patientCpf)
        {
            var consultations = await _consultationRepository.GetConsultationsByPatientCpf(patientCpf);
            if (consultations.Item1)
            {
                return (true, string.Empty, _mapper.Map<List<ConsultationResponse>>(consultations.Item3));
            }
            return (false, "Consultations not found", null);
        }
        public async Task<(bool, string, ConsultationResponse?)> AddConsultation(AppointmentRequest appointmentRequest)
        {
            var doctorConsultation = await VerifyDoctorCalendar(appointmentRequest.DoctorCrm, appointmentRequest.Date);
            if (!doctorConsultation)
            {
                return (false, "Doctor already has a consultation scheduled for this date", null);
            }
            var patient = await _patientRepository.GetPatientByCpf(appointmentRequest.PatientCpf);
            var doctor = await _doctorRepository.GetDoctorByCrm(appointmentRequest.DoctorCrm);
            if(!patient.Item1 || !doctor.Item1)
            {
                return (false, "Patient or Doctor not found", null);
            }
            var consultationRequest = new ConsultationRequest(appointmentRequest.Description,appointmentRequest.Date, doctor.Item3!, patient.Item3!);
            var result = await _consultationRepository.AddConsultation(_mapper.Map<Consultation>(consultationRequest));
            if (result.Item1)
            {
                return (true, string.Empty, _mapper.Map<ConsultationResponse>(result.Item3));
            }
            return (false, "Error adding consultation", null);
        }
        public async Task<(bool, string, ConsultationResponse?)> UpdateConsultation(ConsultationRequest consultation)
        {
            var result = await _consultationRepository.UpdateConsultation(_mapper.Map<Consultation>(consultation));
            if (result.Item1)
            {
                return (true, string.Empty, _mapper.Map<ConsultationResponse>(result.Item3));
            }
            return (false, "Error updating consultation", null);
        }
        public async Task<(bool, string)> DeleteConsultation(ConsultationRequest consultation)
        {
            var result = await _consultationRepository.DeleteConsultation(_mapper.Map<Consultation>(consultation));
            if (result.Item1)
            {
                return (true, string.Empty);
            }
            return (false, "Error deleting consultation");
        }
        public async Task<bool> VerifyDoctorCalendar(string doctorCrm, DateTime date)
        {
            var consultations = await _consultationRepository.GetConsultationsByDoctorCrm(doctorCrm);
            if (consultations.Item1)
            {
                if(consultations.Item3!.FirstOrDefault(x=>x.Date == date) == null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}