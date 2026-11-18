using System.Text.Json.Serialization;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers and JSON configuration
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());

        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shared JSON directory
string dataDirectory = DataDirectory.Resolve();

string assetsPath = Path.Combine(
    dataDirectory,
    "assets.json"
);

// Dependency Injection
builder.Services.AddScoped<IAssetRepository>(
    provider => new JsonAssetRepository(assetsPath));

builder.Services.AddScoped<ValidInput>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<BorrowingService>();
builder.Services.AddScoped<MaintenanceService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// API information
app.MapGet("/", () => Results.Ok(new
{
    Name = "Campus IT Asset & Lab Tracker API",
    Version = ".NET 8",
    Endpoint = "/api/assets",
    Swagger = "/swagger"
}));

app.MapGet("/health", () =>
    Results.Ok(new { Status = "Healthy" }));

app.MapControllers();

app.Run();