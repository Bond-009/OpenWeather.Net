using Newtonsoft.Json;

namespace OpenWeather
{
    public class Clouds
    {
        /// <summary>
        /// Cloudiness, %
        /// </summary>
        [JsonProperty("all")]
        [JsonRequired]
        public int Cloudiness { get; set; }
    }
}
