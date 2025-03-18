using AutoMapper;
using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }

        public async Task<(bool, string, List<PatientResponse>?)> GetAllPatients()
        {
            var patients = await patientRepository.GetAllPatients();
            if (patients.Item1)
            {
                return (true, string.Empty, mapper.Map<List<PatientResponse>>(patients.Item3));
            }
            return (false, "Error when searching for patients", null);
        }

        public async Task<(bool, string, PatientResponse?)> GetPatientByCpf(string cpf)
        {
            var patient = await patientRepository.GetPatientByCpf(cpf);
            if (patient.Item1)
            {
                return (true, string.Empty, mapper.Map<PatientResponse>(patient.Item3));
            }
            return (false, "Error when searching for patient", null);
        }

        public async Task<(bool, string, PatientResponse?)> GetPatientByName(string name)
        {
            var patient = await patientRepository.GetPatientByName(name);
            if (patient.Item1)
            {
                return (true, string.Empty, mapper.Map<PatientResponse>(patient.Item3));
            }
            return (false, "Error when searching for patient", null);
        }
        public async Task<(bool, string, PatientResponse?)> AddPatient(PatientRequest patient)
        {
            var result = await patientRepository.AddPatient(mapper.Map<Patient>(patient));
            if (result.Item1)
            {
                return (true, string.Empty, mapper.Map<PatientResponse>(result.Item3));
            }
            return (false, "Error when adding patient", null);
        }
        public async Task<(bool, string, PatientResponse?)> UpdatePatient(PatientRequest patient)
        {
            var result = await patientRepository.UpdatePatient(mapper.Map<Patient>(patient));
            if (result.Item1)
            {
                return (true, string.Empty, mapper.Map<PatientResponse>(result.Item3));
            }
            return (false, "Error when updating patient", null);
        }
        public async Task<(bool, string)> DeletePatient(PatientRequest patient)
        {
            var result = await patientRepository.DeletePatient(mapper.Map<Patient>(patient));
            if (result.Item1)
            {
                return (true, string.Empty);
            }
            return (false, "Error when deleting patient");
        }       
    }
}