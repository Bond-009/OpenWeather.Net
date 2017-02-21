using System;
using System.Xml.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Info about the weather
    /// </summary>
    [XmlRoot("current")]
    public class WeatherInfo
    {
        [XmlElement("city")]
        public City City { get; set; } = new City();
        [XmlElement("temperature")]
        public Temperature Temperature { get; set; } = new Temperature();
        [XmlElement("humidity")]
        public Humidity Humidity { get; set; } = new Humidity();
        [XmlElement("pressure")]
        public Pressure Pressure { get; set; } = new Pressure();
        [XmlElement("wind")]
        public Wind Wind { get; set; } = new Wind();
        [XmlElement("cloud")]
        public Clouds Clouds { get; set; } = new Clouds();
        [XmlElement("visibility")]
        public Visibility Visibility { get; set; } = new Visibility();
        [XmlElement("precipitation")]
        public Precipitation Precipitation { get; set; } = new Precipitation();
        [XmlElement("weather")]
        public Weather Weather { get; set; } = new Weather();
        public DateTime Lastupdate { get; set; }
    }
}
