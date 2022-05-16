using Microsoft.AspNetCore.Mvc;

namespace APIStyle.Controllers
{
    [ApiController]  //API controller bu normal cont. değil bu yüzden view yok ama normal mvc ye çevrililebilir view ekleyerek ama girmicez ona 
    [Route("[controller]/[action]")] // /action ekledik
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

        [HttpGet(Name = "Forecast")] // ismi kısatalım GetWeatherForecast yerine
        public IEnumerable<WeatherForecast> Forecast() // Get olan metod adını  Forecast yaptık
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "Forecast2")]
        public IEnumerable<WeatherForecast> Forecast2() // Get i Forecast yaptık
        {
            return Enumerable.Range(3, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
}