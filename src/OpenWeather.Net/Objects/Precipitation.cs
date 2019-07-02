using Newtonsoft.Json;

namespace OpenWeather
{
    public class Precipitation
    {
        /// <summary>
        /// Volume for the last 3 hours.
        /// </summary>
        [JsonProperty("3h")]
        [JsonRequired]
        public int Volume { get; set; }
    }
}
