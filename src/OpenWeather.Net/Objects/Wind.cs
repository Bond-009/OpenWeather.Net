using Newtonsoft.Json;

namespace OpenWeather
{
    public class Wind
    {
        /// <summary>
        /// Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonProperty("speed")]
        [JsonRequired]
        public double Speed { get; set; }
        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        [JsonProperty("deg")]
        [JsonRequired]
        public int Degrees { get; set; }
    }
}
