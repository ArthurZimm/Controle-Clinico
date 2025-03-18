using System.ComponentModel.DataAnnotations;

namespace ControleClinico.Application.DTOs.Request
{
    public class UserRequest
    {
        [EmailAddress(ErrorMessage = "Email is required")]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}