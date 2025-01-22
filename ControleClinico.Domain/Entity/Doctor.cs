using ControleClinico.Domain.Common;

namespace ControleClinico.Domain.Entity
{
    public class Doctor : UserIdentifier
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Crm { get; set; }
        public string Specialty { get; set; }
    }
}