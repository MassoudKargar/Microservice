using Microsoft.AspNetCore.Mvc;
using Ms.EntitiesSample.IdGenerators.Contract;

namespace Ms.EntitiesSample.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

[ApiController]
[Route("[controller]")]
public class IdGeneratorController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IdGenerator _idGenerator;

    public IdGeneratorController(ILogger<WeatherForecastController> logger, IdGenerator idGenerator)
    {
        _logger = logger;
        _idGenerator = idGenerator;
    }

    [HttpGet(Name = "Generate")]
    public long Get()
    {
        return _idGenerator.Next();
    }
}