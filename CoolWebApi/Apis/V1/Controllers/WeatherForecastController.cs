using CoolWebApi.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CoolWebApi.Apis.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// This API returns list of weather forecast.
        /// </summary>
        /// <remarks>
        /// Possible values could be:
        ///
        ///     "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        ///     "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ///
        /// Just for demonstration
        ///
        ///     GET api/v1/WeatherForecast
        ///     {
        ///     }
        ///     curl -X GET "https://server-url/api/v1/WeatherForecast" -H  "accept: text/plain"
        ///
        /// </remarks>
        /// <response code="200">Returns list of weather forecast</response>
        /// <response code="400">Noway, just for demonstration</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
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
            throw new DomainException("Product could not be found");
        }
    }

    public class DummyModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName { get; set; }
    }
}