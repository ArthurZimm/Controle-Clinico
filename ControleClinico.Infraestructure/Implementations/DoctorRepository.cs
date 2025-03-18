using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Domain.Entity;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicalDbContext _clinicalDbContext;

        public DoctorRepository(ClinicalDbContext clinicalDbContext)
        {
            _clinicalDbContext = clinicalDbContext;
        }

        public async Task<(bool, string, List<Doctor>?)> GetAllDoctors()
        {
            try
            {
                var doctors = await _clinicalDbContext.Doctors.ToListAsync();
                return (true, string.Empty, doctors);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, Doctor?)> GetDoctorByCrm(string crm)
        {
            try
            {
                var doctor = await _clinicalDbContext.Doctors.FirstOrDefaultAsync(d => d.Crm == crm);
                if(doctor == null)
                {
                    return (false, "Doctor not found", null);
                }
                return (true, string.Empty, doctor);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string, Doctor?)> AddDoctor(Doctor doctor)
        {
            try
            {
                await _clinicalDbContext.Doctors.AddAsync(doctor);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, doctor);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
        public async Task<(bool, string, Doctor?)> UpdateDoctor(Doctor doctor)
        {
            try
            {
                var doctorToUpdate = await _clinicalDbContext.Doctors.FirstOrDefaultAsync(d => d.Crm == doctor.Crm);
                if(doctorToUpdate == null)
                {
                    return (false, "Doctor not found", null);
                }
                doctorToUpdate.Name = doctor.Name;
                doctorToUpdate.Crm = doctor.Crm;
                doctorToUpdate.Age = doctor.Age;
                doctorToUpdate.Specialty = doctor.Specialty;
                doctorToUpdate.Phone = doctor.Phone;
                doctorToUpdate.Email = doctor.Email;
                _clinicalDbContext.Doctors.Update(doctorToUpdate);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty, doctorToUpdate);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public async Task<(bool, string)> DeleteDoctor(Doctor doctor)
        {
            try
            {
                var doctorToDelete = await _clinicalDbContext.Doctors.FirstOrDefaultAsync(d => d.Crm == doctor.Crm);
                if(doctorToDelete == null)
                {
                    return (false, "Doctor not found");
                }
                _clinicalDbContext.Doctors.Remove(doctorToDelete);
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