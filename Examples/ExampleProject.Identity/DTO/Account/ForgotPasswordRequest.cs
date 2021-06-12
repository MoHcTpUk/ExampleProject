using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Identity.DTO.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
