using System.ComponentModel.DataAnnotations;

namespace WeatherCheckApi.Requests
{
    public record LoginRequest(
        [Required, EmailAddress] string Email,
        [Required, RegularExpression("^(?=.*[0-9]).{8,}$")] string Password
    );
}
