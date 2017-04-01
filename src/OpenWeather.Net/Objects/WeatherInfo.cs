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
        public City City { get; set; }
        [XmlElement("temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement("humidity")]
        public Humidity Humidity { get; set; }
        [XmlElement("pressure")]
        public Pressure Pressure { get; set; }
        [XmlElement("wind")]
        public Wind Wind { get; set; }
        [XmlElement("cloud")]
        public Clouds Clouds { get; set; }
        [XmlElement("visibility")]
        public Visibility Visibility { get; set; }
        [XmlElement("precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement("weather")]
        public Weather Weather { get; set; }
        public DateTime Lastupdate { get; set; }
    }
}
