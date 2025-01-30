using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            this.consultationService = consultationService;
        }

        [HttpGet("/get-all-consultations")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await consultationService.GetAllAsync();
            if (!result.result)
            {
                return BadRequest(result.message);
            }
            return Ok(result.response);
        }

        [HttpGet("/get-consultation/{id}")]
        public async Task<IActionResult> GetConsultationById([FromRoute]int id)
        {
            var result = await consultationService.GetConsultationById(id);
            if (!result.result)
            {
                return BadRequest(result.message);
            }
            return Ok(result.response);
        }

        [HttpPost("/add-consultation")]
        public async Task<IActionResult> AddAsync([FromBody] ConsultationRequest entity)
        {
            var result = await consultationService.AddAsync(entity);
            if (!result.result)
            {
                return BadRequest(result.message);
            }
            return Ok(result.response);
        }
        [HttpPut("/update-consultation")]
        public async Task<IActionResult> UpdateAsync([FromBody] ConsultationRequest entity)
        {
            var result = await consultationService.UpdateAsync(entity);
            if (!result.result)
            {
                return BadRequest(result.message);
            }
            return Ok(result.response);
        }

        [HttpDelete("/delete-consultation/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await consultationService.DeleteAsync(id);
            if (!result.result)
            {
                return BadRequest(result.message);
            }
            return Ok(result);
        }
    }
}