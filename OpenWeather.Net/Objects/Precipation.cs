using System.Xml.Serialization;

namespace OpenWeather
{
    public class Precipitation
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
        [XmlAttribute("mode")]
        public string Mode { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
