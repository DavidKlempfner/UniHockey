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
            return await Test(id, null);
        }

        [HttpGet("{str:alpha}")]
        [ResponseCache(CacheProfileName = "GeneralCache")]
        public async Task<string> GetStr(string str)
        {
            return await Test(default, str);
        }

        private async Task<string> Test(int id, string? str)
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

            var reqHeaderEntries = Request.Headers
                .OrderBy(h => h.Key, StringComparer.OrdinalIgnoreCase)
                .Select(h => $"{h.Key}: {string.Join($", ", h.Value)}");
            string allReqHeaders = string.Join(Environment.NewLine, reqHeaderEntries);

            var respHeaderEntries = Response.Headers
                .OrderBy(h => h.Key, StringComparer.OrdinalIgnoreCase)
                .Select(h => $"{h.Key}: {string.Join(", ", h.Value)}");
            string allRespHeaders = string.Join(Environment.NewLine, respHeaderEntries);

            return $"\n\nAllHeaders:\n\n{allReqHeaders}\n\nallRespHeaders:\n\n{allRespHeaders}\n\nHi! id = {id} str = {str}{_david}, {_cassie} - containerHostname = {containerHostname}, processID = {processId}, {osDescription}\n\nExternal API Response:\n{externalData}";
        }
    }
}