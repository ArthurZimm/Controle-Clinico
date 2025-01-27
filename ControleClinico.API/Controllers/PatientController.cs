using AutoMapper;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet("/get-all-patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await patientService.GetAllAsync();
            if(result.result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("/add-patient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientRequest patient)
        {
            var result = await patientService.AddAsync(patient);
            if(result.result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("/update-patient")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientRequest patient)
        {
            var result = await patientService.UpdateAsync(patient);
            if(result.result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("/delete-patient/{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            var result = await patientService.DeleteAsync(id);
            if(result.result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
