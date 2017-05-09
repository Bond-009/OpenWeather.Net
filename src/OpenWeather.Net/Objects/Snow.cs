using Newtonsoft.Json;

namespace OpenWeather
{
    public class Snow
    {
        /// <summary>
        /// Snow volume for the last 3 hours
        /// </summary>
        [JsonProperty("3h")]
        [JsonRequired]
        public int Volume { get; set; }
    }
}
