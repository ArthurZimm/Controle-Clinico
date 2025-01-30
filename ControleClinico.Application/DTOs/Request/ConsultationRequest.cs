using ControleClinico.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Application.DTOs.Request
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "A descrição é requerida")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O nome do paciente é requerido")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "O nome do médico é requerido")]
        public string DoctorName { get; set; }
        public Doctor Doctor { get; set; } = null;
        public Patient Patient { get; set; } = null;
    }
}