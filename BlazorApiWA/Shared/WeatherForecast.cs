namespace BlazorApiWA.Shared;

/// <summary>
/// Class that represents example forecast data.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// The date of the forecast.
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// The temperature of the forecast in degrees celsius.
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// <para>The temperature of the forecast in degrees fahrenheit.</para>
    /// <para>
    /// Property is <c>get</c> only and uses <see cref="TemperatureC"/> to calculate value.
    /// </para>
    /// </summary>
    public int TemperatureF => (TemperatureC * 9) / 5 + 32;

    /// <summary>
    /// A one-word summary of the forecast.
    /// </summary>
    public string Summary { get; set; } = default!;

    /// <summary>
    /// List of one-word summaries to use for <see cref="Summary"/>.
    /// </summary>
    public static readonly string[] Summaries =
[
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
}
