using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UniHockey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly string _david = "";
        private readonly string _cassie = "";

        public WeatherForecastController(IOptions<UniHockeySettings> settings)
        {
            _david = settings.Value.David;
            _cassie = settings.Value.Cassie;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            var containerHostname = Environment.MachineName;
            var processId = Environment.ProcessId;
            var osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            return $"Hi! - {_david}, {_cassie} - {containerHostname}, {processId}, {osDescription}";
        }
    }
}
