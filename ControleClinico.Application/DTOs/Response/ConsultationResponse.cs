namespace ControleClinico.Application.DTOs.Response
{
    public class ConsultationResponse
    {
        public string Description { get; set; }
        public DateTime Date{ get; set; }
        public DoctorResponse Doctor { get; set; }
        public PatientResponse Patient { get; set; }
    }
}