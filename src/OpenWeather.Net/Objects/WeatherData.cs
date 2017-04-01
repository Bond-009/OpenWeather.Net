using System;
using System.Xml.Serialization;

namespace OpenWeather
{
    /// <summary>
    /// Weather forecast for 5 days
    /// </summary>
    [XmlRoot("weatherdata")]
    public class WeatherData
    {
        [XmlElement("location")]
        public Location Location { get; set; }
        // TODO: Add credit
    }
}
