using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Cloudiness.
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Cloudiness, %.
        /// </summary>
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }
}
