using System.Xml.Serialization;

namespace OpenWeather
{
    public class Pressure
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
