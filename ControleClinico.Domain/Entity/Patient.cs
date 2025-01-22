using ControleClinico.Domain.Common;

namespace ControleClinico.Domain.Entity
{
    public class Patient : UserIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public virtual Address Address { get; set; }
    }
}