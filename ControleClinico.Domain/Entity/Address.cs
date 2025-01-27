using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A rua é requerido")]
        [StringLength(60, ErrorMessage = "A rua deve ter no máximo 60 caracteres")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O número é requerido")]
        [StringLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres")]
        public string Number { get; set; }

        [Required(ErrorMessage = "A cidade é requerido")]
        [StringLength(60, ErrorMessage = "A cidade deve ter no máximo 60 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "O estado é requerido")]
        [StringLength(2, ErrorMessage = "O estado deve ter no máximo 2 caracteres")]
        public string State { get; set; }

        [Required(ErrorMessage = "O CEP é requerido")]
        [StringLength(8, ErrorMessage = "O CEP deve ter no máximo 8 caracteres")]
        public string ZipCode { get; set; }
    }
}