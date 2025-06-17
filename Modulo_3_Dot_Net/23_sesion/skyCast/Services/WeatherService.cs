using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services;

public class WeatherService
{
    private readonly HttpClient _http;
    private readonly string _key;
    private const string baseURL = "https://openweathermap.org/data/2.5/";

    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _key = config["OpenWeather.Key"] ?? "";
    }

    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";
        return await _http.GetFromJsonAsync<WeatherDto>(url);
    }

}

/*
    https://openweathermap.org/api/hourly-forecast#name5
No es brujería es tecnología
9:32
var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";
    No es brujería es tecnología
9:35
https://github.com/josejesusguzman/dotmetweathermega


046c9712c94851ac11db6b4139309181
SkyCast


https://home.openweathermap.org/api_keys
rcarvajal
Abuelita99

*/