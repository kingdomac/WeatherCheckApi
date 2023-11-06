namespace WeatherCheckApi.Infrastructure.Helpers
{
    public class PasswordHelper
    {
        public static bool Verify(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
