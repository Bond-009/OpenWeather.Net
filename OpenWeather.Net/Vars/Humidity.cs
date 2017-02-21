using System.Xml.Serialization;

namespace OpenWeather
{
    public class Humidity
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
