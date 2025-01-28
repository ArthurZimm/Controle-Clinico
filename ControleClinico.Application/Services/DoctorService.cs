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
        private readonly IAsyncRepository<Doctor> doctorRepository;
        private readonly IMapper mapper;

        public DoctorService(IAsyncRepository<Doctor> doctorRepository, IMapper mapper)
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }

        public async Task<(bool result, string message, IReadOnlyList<DoctorResponse>? response)> GetAllAsync()
        {
            try
            {
                var doctorList = doctorRepository.GetAllAsync();
                if (doctorList == null)
                {
                    return (false, "Nenhum médico encontrado", null);
                }
                return (true, string.Empty, mapper.Map<IReadOnlyList<DoctorResponse>>(doctorList));
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message, DoctorResponse? response)> AddAsync(DoctorRequest entity)
        {
            try
            {
                var doctor = await doctorRepository.GetByNameAsync(entity.Name);
                if (doctor == null)
                {
                    var result = await doctorRepository.AddAsync(mapper.Map<Doctor>(entity));
                    if (result == null)
                    {
                        return (false, "Ocorreu um erro ao enviar os dados", null);
                    }
                    return (true, string.Empty, mapper.Map<DoctorResponse>(result));
                }
                return (false, "Médico já cadastrado", mapper.Map<DoctorResponse>(doctor));
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message, DoctorResponse? response)> UpdateAsync(DoctorRequest entity)
        {
            try
            {
                var doctor = await doctorRepository.GetByNameAsync(entity.Name);
                if (doctor == null)
                {
                    return (false, "Médico não encontrado", null);
                }
                var result = await doctorRepository.UpdateAsync(mapper.Map<Doctor>(entity));
                if (result == null)
                {
                    return (false, "Ocorreu um erro ao enviar os dados", null);
                }
                return (true, string.Empty, mapper.Map<DoctorResponse>(result));
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
                var doctor = doctorRepository.GetByIdAsync(id);
                if (doctor == null)
                {
                    return (false, "Médico não encontrado");
                }
                await doctorRepository.DeleteAsync(mapper.Map<Doctor>(doctor));
                return (true, "Médico removido com sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}