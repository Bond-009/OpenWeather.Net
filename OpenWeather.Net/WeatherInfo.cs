using System;

namespace OpenWeather
{
    /// <summary>
    /// Info about the weather
    /// </summary>
    public class WeatherInfo
    {
        public City City { get; set; } = new City();
        public Temperature Temperature { get; set; } = new Temperature();
        public Humidity Humidity { get; set; } = new Humidity();
        public Pressure Pressure { get; set; } = new Pressure();
        public Wind Wind { get; set; } = new Wind();
        public Clouds Clouds { get; set; } = new Clouds();
        //TODO: Add visibility
        public Precipitation Precipitation { get; set; } = new Precipitation();
        public Weather Weather { get; set; } = new Weather();

        /// <summary>
        /// URL to the icon
        /// </summary>
        public string IconURL { get; set; }
        public DateTime Lastupdate { get; set; }
    }
}
