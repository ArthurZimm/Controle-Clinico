using ControleClinico.API.Models;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [Authorize]
        [HttpGet("/get-all-patients")]
        public async Task<ReturnModel> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            if (patients.Item1)
            {
                return new ReturnModel(200, string.Empty, patients.Item3);
            }
            return new ReturnModel(404, patients.Item2, default);
        }
        [Authorize]
        [HttpGet("/get-patient/cpf/{cpf}")]
        public async Task<ReturnModel> GetPatientByCpf(string cpf)
        {
            var patient = await _patientService.GetPatientByCpf(cpf);
            if (patient.Item1)
            {
                return new ReturnModel(200, string.Empty, patient.Item3);
            }
            return new ReturnModel(404, patient.Item2, default);
        }
        [Authorize]
        [HttpGet("/get-patient/name/{name}")]
        public async Task<ReturnModel> GetPatientByName(string name)
        {
            var patient = await _patientService.GetPatientByName(name);
            if (patient.Item1)
            {
                return new ReturnModel(200, string.Empty, patient.Item3);
            }
            return new ReturnModel(404, patient.Item2, default);
        }
        [Authorize]
        [HttpPost("/add-patient")]
        public async Task<ReturnModel> AddPatient([FromBody]PatientRequest patient)
        {
            var result = await _patientService.AddPatient(patient);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(400, result.Item2, default);
        }
        [Authorize]
        [HttpPut("/update-patient")]
        public async Task<ReturnModel> UpdatePatient([FromBody] PatientRequest patient)
        {
            var result = await _patientService.UpdatePatient(patient);
            if (result.Item1)
            {
                return new ReturnModel(200, string.Empty, result.Item3);
            }
            return new ReturnModel(400, result.Item2, default);
        }
        [Authorize]
        [HttpDelete("/delete-patient")]
        public async Task<ReturnModel> DeletePatient([FromBody] PatientRequest patient)
        {
            var result = await _patientService.DeletePatient(patient);
            if (result.Item1)
            {
                return new ReturnModel(204, string.Empty, default);
            }
            return new ReturnModel(400, result.Item2, default);
        }
    }
}
