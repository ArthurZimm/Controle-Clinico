using ControleClinico.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Entity
{
    public class User : UserIdentifier
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "O campo Email deve ser um email válido")]
        public string Email { get; set; }
    }
}