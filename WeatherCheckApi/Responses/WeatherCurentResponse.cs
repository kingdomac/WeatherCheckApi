using System.Text.Json.Serialization;

namespace WeatherCheckApi.Responses
{
    public class WeatherCurentResponse
    {
        [JsonPropertyName("temp_c")]
        public float TemperatureCelsius { get; set; }

        [JsonPropertyName("wind_kph")]
        public float WindSpeedKph { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
