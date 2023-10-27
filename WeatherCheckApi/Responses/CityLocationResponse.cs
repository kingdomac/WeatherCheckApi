using System.Text.Json.Serialization;

namespace WeatherCheckApi.Responses
{
    public class CityLocationResponse
    {
        [JsonPropertyName("name")]
        public string CityName { get; set; }
    }
}
