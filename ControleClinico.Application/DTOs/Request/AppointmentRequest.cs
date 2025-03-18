using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Application.DTOs.Request
{
    public class AppointmentRequest
    {
        [Required(ErrorMessage = "A descrição da consulta é requerida")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A data da consulta é requerida")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O cpf do paciente é requerido")]
        public string PatientCpf { get; set; }
        [Required(ErrorMessage = "O crm do médico é requerido")]
        public string DoctorCrm { get; set; }
    }
}