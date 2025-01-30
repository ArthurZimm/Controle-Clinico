using ControleClinico.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Entity
{
    public class Consultation : UserIdentifier
    {
        [Required(ErrorMessage = "A descrição é requerida")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime Date { get; set; }
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}