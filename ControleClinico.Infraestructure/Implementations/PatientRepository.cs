using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Domain.Entity;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicalDbContext _clinicalDbContext;

        public PatientRepository(ClinicalDbContext clinicalDbContext)
        {
            _clinicalDbContext = clinicalDbContext;
        }
        public async Task<(bool, string, List<Patient>?)> GetAllPatients()
        {
            try
            {
                return (true, string.Empty, await _clinicalDbContext.Patients.ToListAsync());
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, Patient?)> GetPatientByCpf(string cpf)
        {
            try
            {
                var patient = await _clinicalDbContext.Patients.FirstOrDefaultAsync(p => p.Cpf == cpf);
                if(patient == null)
                {
                    return (false, "Patient not found", null);
                }
                return (true, string.Empty, patient);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, Patient?)> GetPatientByName(string name)
        {
            try
            {
                var patient = await _clinicalDbContext.Patients.FirstOrDefaultAsync(p => p.Name == name);
                if(patient == null)
                {
                    return (false, "Patient not found", null);
                }
                return (true, string.Empty, patient);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, Patient?)> AddPatient(Patient patient)
        {
            try
            {
                var newPatient = await _clinicalDbContext.Patients.AddAsync(patient);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, newPatient.Entity);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }


        public async Task<(bool, string, Patient?)> UpdatePatient(Patient patient)
        {
            try
            {
                var patientToUpdate = await _clinicalDbContext.Patients.FirstOrDefaultAsync(p => p.Cpf == patient.Cpf);
                if(patientToUpdate == null)
                {
                    return (false, "Patient not found", null);
                }
                patientToUpdate.Name = patient.Name;
                patientToUpdate.Age = patient.Age;
                patientToUpdate.Phone = patient.Phone;
                patientToUpdate.Email = patient.Email;
                patientToUpdate.Address = patient.Address;
                patientToUpdate.Consultations = patient.Consultations;
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, patientToUpdate);
            }
            catch(Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool, string)> DeletePatient(Patient patient)
        {
            try
            {
                var patientToDelete = await _clinicalDbContext.Patients.FirstOrDefaultAsync(p => p.Cpf == patient.Cpf);
                if(patientToDelete == null)
                {
                    return (false, "Patient not found");
                }
                _clinicalDbContext.Patients.Remove(patientToDelete);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}