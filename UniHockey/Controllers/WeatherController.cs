using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UniHockey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly string _david = "";
        private readonly string _cassie = "";
        private readonly HttpClient _httpClient;

        public WeatherController(IOptions<UniHockeySettings> settings, HttpClient httpClient)
        {
            _david = settings.Value.David;
            _cassie = settings.Value.Cassie;
            _httpClient = httpClient;
        }

        [HttpGet("{id:int}")]
        [ResponseCache(CacheProfileName = "GeneralCache")]
        public async Task<string> Get(int id)
        {
            var containerHostname = Environment.MachineName;
            var processId = Environment.ProcessId;
            var osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            // make a GET request to https://jsonplaceholder.typicode.com/posts/1
            string externalData = "";
            try
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
                if (response.IsSuccessStatusCode)
                {
                    externalData = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    externalData = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                externalData = $"Exception: {ex.Message}";
            }

            
            var customRequestHeader = Request.Headers["X-Test-Header"];

            return $"Hi! id = {id} - X-Test-Header: {customRequestHeader} - {_david}, {_cassie} - {containerHostname}, {processId}, {osDescription}\n\nExternal API Response:\n{externalData}";
        }
    }
}