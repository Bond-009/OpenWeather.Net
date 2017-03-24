using System.Xml.Serialization;

namespace OpenWeather
{
    public class Direction
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
