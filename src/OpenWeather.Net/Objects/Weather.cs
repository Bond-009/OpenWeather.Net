using Newtonsoft.Json;

namespace OpenWeather
{
    public class Weather
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        [JsonProperty("id")]
        [JsonRequired]
        public int ID { get; set; }

        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        [JsonProperty("main")]
        [JsonRequired]
        public string Main { get; set; }

        /// <summary>
        /// Weather condition within the group
        /// </summary>
        [JsonProperty("description")]
        [JsonRequired]
        public string Description { get; set; }

        /// <summary>
        /// Weather icon id
        /// </summary>
        [JsonProperty("icon")]
        [JsonRequired]
        public string Icon { get; set; }
    }
}
