using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace OpenWeather
{
    /// <summary>
    /// Current weather data for one location
    /// </summary>
    public class WeatherData
    {
        [JsonProperty("coord")]
        [JsonRequired]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("weather")]
        [JsonRequired]
        public Weather[] Weather { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("base")]
        [JsonRequired]
        public string Base { get; set; }
        [JsonProperty("main")]
        [JsonRequired]
        public Main Main { get; set; }
        // TODO: Add visibility
        [JsonProperty("wind")]
        [JsonRequired]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        [JsonRequired]
        public Clouds Clouds { get; set; }
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
        [JsonProperty("snow")]
        public Snow Snow { get; set; }
        /// <summary>
        /// Time of data calculation, unix, UTC
        /// </summary>
        [JsonProperty("dt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonRequired]
        public DateTime DateTime { get; set; }
        [JsonProperty("sys")]
        [JsonRequired]
        public Sys Sys { get; set; }
        /// <summary>
        /// City ID
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int ID { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("cod")]
        [JsonRequired]
        public int COD { get; set; }
    }
}
