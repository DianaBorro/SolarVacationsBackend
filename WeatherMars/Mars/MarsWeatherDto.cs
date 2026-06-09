using System.Text.Json.Serialization;

namespace WeatherMars.NASAEndpoint;

record MarsWeatherDto(
    [property: JsonPropertyName("sol")] string Sol,

    [property: JsonPropertyName("min_temp")] string? MinTemp,

    [property: JsonPropertyName("max_temp")] string? MaxTemp,

    [property: JsonPropertyName("pressure")] string Pressure
);