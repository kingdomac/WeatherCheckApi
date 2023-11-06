using System.Text;

namespace WeatherCheckApi.Infrastructure.Helpers
{
    public class TokenHelper
    {
        public static string Encode(string token)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
        }

        public static string Decode(string base64String)
        {
            byte[] base64Bytes = Convert.FromBase64String(base64String);
            string decodedString = Encoding.UTF8.GetString(base64Bytes);
            return decodedString;
        }

        public static string Generate()
        {
            // Generate a new GUID
            Guid guid = Guid.NewGuid();

            // Convert the GUID to a string and remove dashes
            string token = guid.ToString("N");

            return token;
        }
    }
}
