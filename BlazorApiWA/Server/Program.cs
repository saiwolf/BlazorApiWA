using BlazorApiWA.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    IServiceCollection services = builder.Services;

    builder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration));

    services.AddControllers();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.MapGet("/api/weather-forecast", Ok<WeatherForecast[]> () =>
    {
        Random rng = new();
        var forecasts = Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = WeatherForecast.Summaries[rng.Next(WeatherForecast.Summaries.Length)]
        }).ToArray();

        return TypedResults.Ok(forecasts);
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception has occurred.\n{exMessage}", ex.Message);
    Environment.Exit(-1);
}
finally
{
    await Log.CloseAndFlushAsync();
}