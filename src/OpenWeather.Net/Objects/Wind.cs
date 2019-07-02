using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Information about the wind.
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Gets or sets the wind speed.
        /// Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        /// Gets ir sets the wind direction, degrees (meteorological).
        /// </summary>
        [JsonPropertyName("deg")]
        public int Degrees { get; set; }
    }
}
