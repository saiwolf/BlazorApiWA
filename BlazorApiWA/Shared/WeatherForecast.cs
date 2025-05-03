﻿namespace BlazorApiWA.Shared;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => (TemperatureC * 9) / 5 + 32;

    public string Summary { get; set; } = default!;

    public static readonly string[] Summaries =
[
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
}
