using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Precipitation information.
    /// </summary>
    public class Precipitation
    {
        /// <summary>
        /// Volume for the last hour, in mm.
        /// </summary>
        [JsonPropertyName("1h")]
        public double? Volume1h { get; set; }

        /// <summary>
        /// Volume for the last 3 hours, in mm.
        /// </summary>
        [JsonPropertyName("3h")]
        public double? Volume3h { get; set; }
    }
}
