namespace WeatherCheckApi.Responses
{
    public class WeatherApiResponse
    {
        public CityLocationResponse? location { get; set; }
        public WeatherCurentResponse? current { get; set; }
    }
}
