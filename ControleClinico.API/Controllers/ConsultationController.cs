using ControleClinico.API.Models;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;
        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }
        [Authorize]
        [HttpGet("/get-consultation/id/{id}")]
        public async Task<ReturnModel> GetConsultationById(Guid id)
        {
            var result = await _consultationService.GetConsultationById(id);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(404, result.Item2, default);
        }
        [Authorize]
        [HttpGet("/get-consultation/doctor-crm/{crm}")]
        public async Task<ReturnModel> GetConsultationByDoctorCrm(string crm)
        {
            var result = await _consultationService.GetConsultationsByDoctorCrm(crm);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(404, result.Item2, default);
        }
        [Authorize]
        [HttpGet("/get-consultation/patient-cpf/{cpf}")]
        public async Task<ReturnModel> GetConsultationByPatientCpf(string cpf)
        {
            var result = await _consultationService.GetConsultationsByPatientCpf(cpf);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(404, result.Item2, default);
        }
        [Authorize]
        [HttpPost("/add-consultation")]
        public async Task<ReturnModel> AddConsultation([FromBody] AppointmentRequest appointmentRequest)
        {
            var result = await _consultationService.AddConsultation(appointmentRequest);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(400, result.Item2, default);
        }
        [Authorize]
        [HttpPut("/update-consultation")]
        public async Task<ReturnModel> UpdateConsultation([FromBody] ConsultationRequest consultation)
        {
            var result = await _consultationService.UpdateConsultation(consultation);
            if (result.Item1)
            {
                return new ReturnModel(204, string.Empty, default);
            }
            return new ReturnModel(400, result.Item2, default);
        }
        [Authorize]
        [HttpDelete("/delete-consultation")]
        public async Task<ReturnModel> DeleteConsultation([FromBody] ConsultationRequest consultation)
        {
            var result = await _consultationService.DeleteConsultation(consultation);
            if (result.Item1)
            {
                return new ReturnModel(204, string.Empty, default);
            }
            return new ReturnModel(400, result.Item2, default);
        }
    }
}