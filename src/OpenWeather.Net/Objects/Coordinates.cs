using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Geo location, longitude and latitude.
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        /// Geo location, longitude.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Geo location, latitude.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}
