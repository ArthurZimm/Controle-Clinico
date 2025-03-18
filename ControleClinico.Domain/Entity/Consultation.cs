using ControleClinico.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Entity
{
    public class Consultation : UserIdentifier
    {
        [Required(ErrorMessage = "A descrição é requerida")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A data é requerida")]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(Consultation), nameof(ValidateDate))]
        public DateTime Date { get; set; }

        public Guid? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public Guid? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public Consultation(string description, DateTime date)
        {
            Description = description;
            Date = date;
        }

        public Consultation() { }

        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date < DateTime.Now)
            {
                return new ValidationResult("A data da consulta não pode ser no passado.");
            }
            return ValidationResult.Success;
        }
    }
}
