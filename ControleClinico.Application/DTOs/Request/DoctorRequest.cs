using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Application.DTOs.Request
{
    public class DoctorRequest
    {
        [Required(ErrorMessage = "O nome é requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O telefone é requerido")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "O email é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A idade é requerida")]
        public int Age { get; set; }
        [Required(ErrorMessage = "O CRM é requerido")]
        public string Crm { get; set; }
        [Required(ErrorMessage = "A especialidade é requerida")]
        public string Specialty { get; set; }
    }
}