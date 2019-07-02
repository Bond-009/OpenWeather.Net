using System;
using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    ///
    /// </summary>
    public class Sys
    {
        /// <summary>
        /// Internal parameter.
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// Internal parameter.
        /// </summary>
        [JsonPropertyName("id")]
        public int ID { get; set; }

        /// <summary>
        /// Internal parameter.
        /// </summary>
        [JsonPropertyName("message")]
        public double Message { get; set; }

        /// <summary>
        /// Country code (GB, JP etc.).
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Sunrise time, UTC.
        /// </summary>
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Sunrise { get; set; }

        /// <summary>
        /// Sunset time, UTC.
        /// </summary>
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset Sunset { get; set; }
    }
}
