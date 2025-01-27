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
        protected readonly IAsyncRepository<Patient> patientRepository;
        private readonly IMapper mapper;

        public PatientService(IAsyncRepository<Patient> patientRepository, IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }
        public async Task<(bool result, string message, IReadOnlyList<PatientResponse>?)> GetAllAsync()
        {
            try
            {
                var patientList = await patientRepository.GetAll();
                if(patientList == null)
                {
                    return (false, "Nenhum paciente encontrado", null);
                }
                return (true, string.Empty, mapper.Map<IReadOnlyList<PatientResponse>>(patientList));
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        
        public async Task<(bool result, string message, PatientResponse? response)> AddAsync(PatientRequest entity)
        {
            try
            {
                var patient = await patientRepository.GetByNameAsync(entity.Name);
                if (patient == null)
                {
                    var result = await patientRepository.AddAsync(mapper.Map<Patient>(entity));
                    if (result == null)
                    {
                        return (false, "Ocorreu um erro ao enviar os dados", null);
                    }
                    return (true, string.Empty, mapper.Map<PatientResponse>(result));
                }
                return (false, "Paciente já cadastrado", mapper.Map<PatientResponse>(patient));
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
                var patient = await patientRepository.GetByIdAsync(id);
                if (patient == null)
                {
                    return (false, "Paciente não encontrado");
                }
                await patientRepository.DeleteAsync(patient);
                return (true, "Paciente removido com sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool result, string message, PatientResponse? response)> UpdateAsync(PatientRequest entity)
        {
            try
            {
                var patient = await patientRepository.GetByNameAsync(entity.Name);
                if (patient == null)
                {
                    return (false, "Paciente não encontrado", null);
                }
                var result = await patientRepository.UpdateAsync(mapper.Map<Patient>(entity));
                if (result == null)
                {
                    return (false, "Ocorreu um erro ao enviar os dados", null);
                }
                return (true, string.Empty, mapper.Map<PatientResponse>(result));
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}