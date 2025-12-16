using Microsoft.AspNetCore.Mvc;

namespace UniHockey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController
    {
        [HttpGet]
        public string Get()
        {
            return "Healthy";
        }
    }
}