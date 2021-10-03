using System.Text.Json.Serialization;

namespace CoolWebApi.Infrastructure.ProblemDetail
{
    /// <summary>
    /// used for API body when returning a HTTP 400 bad request result
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// The error code
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// A message from and to the Developer
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}