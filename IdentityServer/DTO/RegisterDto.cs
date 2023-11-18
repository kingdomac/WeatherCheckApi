using System.ComponentModel.DataAnnotations;

namespace IdentityServer.DTO
{
    public class RegisterDto
    {
        [Required, EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
