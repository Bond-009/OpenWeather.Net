using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Current weather data for one location.
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Gets or sets the geo location, longitude and latitude.
        /// </summary>
        /// <value>The coordinates.</value>
        /// <see cref="Coordinates"/>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }
        
        /// <summary>
        /// Gets or sets all weather conditions.
        /// </summary>
        /// <value>A list of weather conditions.</value>
        [JsonPropertyName("weather")]
        public IReadOnlyList<Weather> Weather { get; set; }

        /// <summary>
        /// Gets or sets the internal parameter 'base'.
        /// </summary>
        /// <value>A string.</value>
        [JsonPropertyName("base")]
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the main weather information.
        /// </summary>
        /// <value>The main weather information.</value>
        /// <see cref="Main"/>
        [JsonPropertyName("main")]
        public Main Main { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>The visibility.</value>
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        /// <summary>
        /// Gets or sets the wind information.
        /// </summary>
        /// <value>The wind information.</value>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        /// Gets or sets the cloud information.
        /// </summary>
        /// <value>The cloud information.</value>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        /// <summary>
        /// Gets or sets the rain information.
        /// </summary>
        /// <value>The rain information.</value>
        [JsonPropertyName("rain")]
        public Precipitation Rain { get; set; }

        /// <summary>
        /// Gets or sets the snow information.
        /// </summary>
        /// <value>The snow information.</value>
        [JsonPropertyName("snow")]
        public Precipitation Snow { get; set; }

        /// <summary>
        /// Gets or sets the time of data calculation, unix, UTC.
        /// </summary>
        /// <value>The time of data calculation.</value>
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        /// <see cref="Sys"/>
        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        /// <summary>
        /// Gets or sets teh city Id
        /// </summary>
        /// <value>the city id</value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        /// <value>The city name</value>>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Internal parameter.
        /// </summary>
        /// <value>An integer.</value>
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}
