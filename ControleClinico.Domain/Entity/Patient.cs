using ControleClinico.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Entity
{
    public class Patient : UserIdentifier
    {
        [Required(ErrorMessage ="O nome é requerido")]
        [StringLength(60, ErrorMessage = "O nome deve ter no máximo 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF é requerido")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O telefone é requerido")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O email é requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A idade é requerida")]
        [Range (0, 120, ErrorMessage = "A idade deve ser entre 0 e 120")]
        public int Age { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}