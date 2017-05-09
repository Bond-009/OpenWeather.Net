using Newtonsoft.Json;

namespace OpenWeather
{
    public class Coordinates
    {
        /// <summary>
        /// City geo location, longitude
        /// </summary>
        [JsonProperty("lon")]
        [JsonRequired]
        public double Longitude { get; set; }
        /// <summary>
        /// City geo location, latitude
        /// </summary>
        [JsonProperty("lat")]
        [JsonRequired]
        public double Latitude { get; set; }
    }
}
