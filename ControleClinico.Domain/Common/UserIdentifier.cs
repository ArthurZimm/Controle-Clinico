using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Domain.Common
{
    public abstract class UserIdentifier
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}