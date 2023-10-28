using System.Text.Json.Serialization;

namespace WeatherCheckApi.Responses
{
    public class WeatherCurentResponse
    {
        [JsonPropertyName("temp_c")]
        public float TemperatureC { get; set; }

        [JsonPropertyName("wind_kph")]
        public float WindSpeedKm { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
