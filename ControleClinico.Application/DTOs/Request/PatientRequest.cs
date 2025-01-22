using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.DTOs.Request
{
    public class PatientRequest
    {
        public PatientRequest(string name, string cpf, string phone, string email, int age, Address address)
        {
            Name = name;
            Cpf = cpf;
            Phone = phone;
            Email = email;
            Age = age;
            Address = address;
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}