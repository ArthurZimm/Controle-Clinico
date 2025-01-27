using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        
        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet("/get-all-doctors")]
        public async Task<IActionResult> GetAll()
        {
            var result = await doctorService.GetAllAsync();
            if (result.result)
            {
                return Ok(result);
            }
            return BadRequest(result.message);
        }

        [HttpPost("/add-doctor")]
        public async Task<IActionResult> AddDoctor(DoctorRequest doctor)
        {
            var result = await doctorService.AddAsync(doctor);
            if (result.result)
            {
                return Ok(result.response);
            }
            return BadRequest(result.message);
        }

        [HttpPut("/update-doctor")]
        public async Task<IActionResult> UpdateDoctor(DoctorRequest doctor)
        {
            var result = await doctorService.UpdateAsync(doctor);
            if (result.result)
            {
                return Ok(result.response);
            }
            return BadRequest(result.message);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute]int id)
        {
            var result = await doctorService.DeleteAsync(id);
            if (result.result)
            {
                return Ok();
            }
            return BadRequest(result.message);
        }
    }
}