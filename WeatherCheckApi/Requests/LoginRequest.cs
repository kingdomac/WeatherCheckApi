using System.ComponentModel.DataAnnotations;

namespace WeatherCheckApi.Requests
{
    public record LoginRequest(
        [Required, EmailAddress] string Email,
        [Required] string Password
    );
}
