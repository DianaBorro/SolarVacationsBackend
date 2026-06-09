using System.Text.Json;

namespace WeatherMars.NASAEndpoint;

public static class MarsEndpoint
{
    public static void MapMarsEndpoint(this WebApplication app)
    {
        app.MapGet("/marsweather", async (HttpClient client) =>
            {
                var response = await client.GetStringAsync("https://api.maas2.apollorion.com/");
    
                var weather = JsonSerializer.Deserialize<MarsWeatherDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    
                return weather is not null
                    ? Results.Ok(weather)
                    : Results.Problem("Could not fetch Mars weather");
            })
            .WithName("GetMarsWeather")
            .WithOpenApi();   
    }
}