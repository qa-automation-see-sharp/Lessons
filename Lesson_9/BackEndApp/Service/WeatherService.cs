using BackEndApp.Models;
using Newtonsoft.Json;

namespace BackEndApp.Service;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "85d77956baca547d1a34188b7e564e22"; 
    private const string WeatherEndpoint = "weather";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    }

    public async Task<WeatherData?> GetWeatherAsync(string city, string countryConde)
    {
        var url = $"{WeatherEndpoint}?q={city},{countryConde}&appid={ApiKey}&units=metric";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<WeatherData>(jsonString);
    }
}