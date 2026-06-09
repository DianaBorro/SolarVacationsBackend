//All the data comes from NASA APIs as of the 29th of May 2026

//just checking
//what about now main branch ruleset

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherMars.NASAEndpoint;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

// app.MapGet("/marsweatherforecast", () =>
//     {
//         var forecast = Enumerable.Range(1, 5).Select(index => { return 2;});
//         return forecast;
//     })
//     .WithName("Getmarsweatherforecast");
app.MapMarsEndpoint();

app.Run();
    