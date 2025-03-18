using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Domain.Entity;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Implementations
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ClinicalDbContext _clinicalDbContext;

        public ConsultationRepository(ClinicalDbContext clinicalDbContext)
        {
            _clinicalDbContext = clinicalDbContext;
        }

        public async Task<(bool, string, Consultation?)> GetConsultationById(Guid id)
        {
            try
            {
                var consultation = await _clinicalDbContext.Consultations.FirstOrDefaultAsync(c => c.Id == id);
                if (consultation == null)
                {
                    return (false, "Consultation not found", null);
                }
                return (true, string.Empty, consultation);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, List<Consultation>?)> GetConsultationsByDoctorCrm(string doctorCrm)
        {
            try
            {
                var consultations = await _clinicalDbContext.Consultations.Where(c => c.Doctor.Crm == doctorCrm)
                    .Include(d => d.Doctor)
                    .Include(p => p.Patient)
                    .ToListAsync();
                if (consultations == null)
                {
                    return (false, "Consultations not found", null);
                }
                return (true, string.Empty, consultations);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, List<Consultation>?)> GetConsultationsByPatientCpf(string patientCpf)
        {
            try
            {
                var consultations = await _clinicalDbContext.Consultations.Where(c => c.Patient.Cpf == patientCpf)
                     .Include(d => d.Doctor)
                    .Include(p => p.Patient)
                    .ToListAsync();
                if (consultations == null)
                {
                    return (false, "Consultations not found", null);
                }
                return (true, string.Empty, consultations);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool, string, Consultation?)> AddConsultation(Consultation consultation)
        {
            try
            {
                await _clinicalDbContext.Consultations.AddAsync(consultation);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, consultation);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool, string, Consultation?)> UpdateConsultation(Consultation consultation)
        {
            try
            {
                var consultationToUpdate = await _clinicalDbContext.Consultations
                    .FirstOrDefaultAsync(x => x.Id == consultation.Id);
                if (consultationToUpdate == null)
                {
                    return (false, "Consultation not found", null);
                }
                _clinicalDbContext.Consultations.Update(consultation);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, consultation);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool, string)> DeleteConsultation(Consultation consultation)
        {
            try
            {
                var consultationToDelete = await _clinicalDbContext.Consultations.FirstOrDefaultAsync(x => x.Id == consultation.Id);
                if (consultationToDelete == null)
                {
                    return (false, "Consultation not found");
                }
                _clinicalDbContext.Consultations.Remove(consultationToDelete);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
