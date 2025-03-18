using ControleClinico.API.Models;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet("/get-all")]
        public async Task<ReturnModel> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            if (doctors.Item1)
            {
                return new ReturnModel(200,string.Empty,doctors.Item3);
            }
            return new ReturnModel(404,string.Empty,default);
        }
        [HttpGet("/get-by-crm/{crm}")]
        public async Task<ReturnModel> GetDoctorByCrm(string crm)
        {
            var doctor = await _doctorService.GetDoctorByCrm(crm);
            if (doctor.Item1)
            {
                return new ReturnModel(200,string.Empty,doctor.Item3);
            }
            return new ReturnModel(404,string.Empty,default);
        }
        [HttpPost("/add-doctor")]
        public async Task<ReturnModel> AddDoctor([FromBody] DoctorRequest doctor)
        {
            var doctorResponse = await _doctorService.AddDoctor(doctor);
            if (doctorResponse.Item1)
            {
                return new ReturnModel(200,string.Empty,doctorResponse.Item3);
            }
            return new ReturnModel(404,string.Empty,default);
        }
        [HttpPut("/update-doctor")]
        public async Task<ReturnModel> UpdateDoctor([FromBody] DoctorRequest doctor)
        {
            var doctorResponse = await _doctorService.UpdateDoctor(doctor);
            if (doctorResponse.Item1)
            {
                return new ReturnModel(200,string.Empty,doctorResponse.Item3);
            }
            return new ReturnModel(404,string.Empty,default);
        }
        [HttpDelete("/delete-doctor")]
        public async Task<ReturnModel> DeleteDoctor([FromBody] DoctorRequest doctor)
        {
            var doctorResponse = await _doctorService.DeleteDoctor(doctor);
            if (doctorResponse.Item1)
            {
                return new ReturnModel(200,string.Empty,default);
            }
            return new ReturnModel(404,string.Empty,default);
        }
    }
}