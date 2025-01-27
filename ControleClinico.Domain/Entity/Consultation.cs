using ControleClinico.Domain.Common;

namespace ControleClinico.Domain.Entity
{
    public class Consultation : UserIdentifier
    {
        public string Description { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}