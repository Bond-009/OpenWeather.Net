using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Basic weather information.
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa.
        /// </summary>
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        /// <summary>
        /// Humidity, %
        /// </summary>
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// Minimum temperature at the moment. This is deviation from current temp that is possible
        /// for large cities and megalopolises geographically expanded (use these parameter optionally).
        /// </summary>
        [JsonPropertyName("temp_min")]
        public double MinimumTemperature { get; set; }

        /// <summary>
        /// Maximum temperature at the moment. This is deviation from current temp that is possible
        /// for large cities and megalopolises geographically expanded (use these parameter optionally).
        /// </summary>
        [JsonPropertyName("temp_max")]
        public double MaximumTemperature { get; set; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonPropertyName("sea_level")]
        public int? PressureSeaLevel { get; set; }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa.
        /// </summary>
        [JsonPropertyName("grnd_level")]
        public int? PressureGroundLevel { get; set; }
    }
}
