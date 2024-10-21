using BackEndApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddHttpClient<WeatherService>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Define a minimal API endpoint
app.MapGet("/weather", async (string city, string countryConde, WeatherService weatherService) =>
    {
        // Extract city name from query parameters
        if (string.IsNullOrEmpty(city))
        {
            return Results.BadRequest("Please provide a city name.");
        }

        try
        {
            // Get weather data from the service
            var weatherData = await weatherService.GetWeatherAsync(city, countryConde);

            // Return the weather data as JSON
            return Results.Ok(new
            {
                City = weatherData.Name,
                Temperature = weatherData.Main.Temp,
                Humidity = weatherData.Main.Humidity,
                Description = weatherData.Weather[0].Description
            });
        }
        catch (HttpRequestException e)
        {
            return Results.Problem($"Error fetching weather data: {e.Message}");
        }
    })
    .WithName("GetWeather")
    .WithTags("Weather")
    .WithOpenApi();

app.Run();