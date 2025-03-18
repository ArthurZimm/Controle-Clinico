using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.DTOs.Request
{
    public class ConsultationRequest
    {
        public ConsultationRequest(string description, DateTime date, Doctor doctor, Patient patient)
        {
            Description = description;
            Date = date;
            Doctor = doctor;
            Patient = patient;
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}