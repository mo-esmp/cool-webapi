using CoolWebApi.Domain;
using CoolWebApi.Infrastructure.HttpClients;
using CoolWebApi.Models;

namespace CoolWebApi.Apis.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherHttpClient _weatherClient;

        public WeatherForecastController(IWeatherHttpClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        /// <summary>
        ///   This API returns list of weather forecast.
        /// </summary>
        /// <remarks>
        ///   Default city is London
        ///
        ///   GET api/v1/WeatherForecast?city=YourCity { } curl -X GET
        ///   "https://server-url/api/v1/WeatherForecast" -H "accept: text/plain"
        /// </remarks>
        /// <response code="200">Returns list of weather forecast</response>
        /// <response code="400">Noway, just for demonstration</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<WeatherForecast>> Get(string city = "London")
        {
            return await _weatherClient.GetForecastsAsync(city);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DummyModel model)
        {
            return Ok();
        }

        [HttpGet("throw-error")]
        public IActionResult ThrowError()
        {
            throw new InvalidOperationException("The exception was intentionally thrown");
        }

        [HttpGet("throw-domain-exception")]
        public IActionResult ThrowDomainError()
        {
            throw new DomainException("The user mobile number is not verified.", code: "120");
        }
    }
}