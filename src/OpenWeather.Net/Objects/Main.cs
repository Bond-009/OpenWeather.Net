using Newtonsoft.Json;

namespace OpenWeather
{
    public class Main
    {
        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty("temp")]
        [JsonRequired]
        public double Temperature { get; set; }
        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        [JsonProperty("pressure")]
        [JsonRequired]
        public int Pressure { get; set; }
        /// <summary>
        /// Humidity, %
        /// </summary>
        [JsonProperty("humidity")]
        [JsonRequired]
        public int Humidity { get; set; }
        /// <summary>
        /// Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty("temp_min")]
        [JsonRequired]
        public double MinimumTemperature { get; set; }
        /// <summary>
        /// Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty("temp_max")]
        [JsonRequired]
        public double MaximumTemperature { get; set; }
    }
}
