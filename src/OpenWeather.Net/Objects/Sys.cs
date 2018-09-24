using Newtonsoft.Json;
using System;

namespace OpenWeather
{
    public class Sys
    {
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("type")]
        [JsonRequired]
        public int Type { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int ID { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("message")]
        [JsonRequired]
        public string Message { get; set; }
        /// <summary>
        /// Country code (GB, JP etc.)
        /// </summary>
        [JsonProperty("country")]
        [JsonRequired]
        public string Country { get; set; }
        /// <summary>
        /// Sunrise time, UTC
        /// </summary>
        [JsonProperty("sunrise")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonRequired]
        public DateTime Sunrise { get; set; }
        /// <summary>
        /// Sunset time, UTC
        /// </summary>
        [JsonProperty("sunset")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonRequired]
        public DateTime Sunset { get; set; }
    }
}
