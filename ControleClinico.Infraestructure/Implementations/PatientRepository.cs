using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Domain.Entity;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ControleClinico.Infraestructure.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicalDbContext _context;

        public PatientRepository(ClinicalDbContext context)
        {
            _context = context;
        }

        public async Task<(bool result, string message, Patient?)> AddAsync(Patient entity)
        {
            try
            {
                await _context.Patients.AddAsync(entity);
                await _context.SaveChangesAsync();
                return (true, "Paciente Adicionado", entity);
            }
            catch (DbException ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool result, string message)> DeleteAsync(Patient entity)
        {
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Cpf == entity.Cpf);
                if (patient == null)
                {
                    return (false, "Patient not found");
                }
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return (true, "Paciente Removido!");
            }
            catch (DbException ex)
            {
                return (false, ex.Message);
            }
        }


        public async Task<(bool result, string message, Patient?)> GetByIdAsync(int id)
        {
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
                if (patient == null)
                {
                    return (false, "Patient not found", null);
                }
                return (true, string.Empty, patient);
            }
            catch (DbException ex)
            {
                return (false, ex.Message, null);
            }
        }


        public async Task<(bool result, string message, Patient response)> GetPatientByName(string patientName)
        {
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Name == patientName);
                if (patient == null)
                {
                    return (false, "Patient not found", null);
                }
                return (true, string.Empty, patient);
            }
            catch (DbException ex)
            {
                return (false, ex.Message, null);
            }
        }


        public async Task<(bool result, string message, IReadOnlyList<Patient?>)> ListAllAsync()
        {
            try
            {
                var patients = await _context.Patients.ToListAsync();
                if (patients == null)
                {
                    return (false, "No patients found", null);
                }
                return (true, string.Empty, patients);
            }
            catch (DbException ex)
            {
                return (false, ex.Message, null);
            }
        }


        public async Task<(bool result, string message)> UpdateAsync(Patient entity)
        {
            try
            {
                var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Cpf == entity.Cpf);
                if (patient == null)
                {
                    return (false, "Paciente não encontrado");
                }
                patient.Name = entity.Name;
                patient.Phone = entity.Phone;
                patient.Email = entity.Email;
                patient.Age = entity.Age;
                patient.Address = entity.Address;
                await _context.SaveChangesAsync();
                return (true, "Paciente Atualizado!");
            }
            catch (DbException ex)
            {
                return (false, ex.Message);
            }
        }
    }
}