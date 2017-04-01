using System.Xml.Serialization;

namespace OpenWeather
{
    public class Wind
    {
        [XmlElement("speed")]
        public Speed Speed { get; set; }
        [XmlElement("direction")]
        public Direction Direction { get; set; }
    }
}
