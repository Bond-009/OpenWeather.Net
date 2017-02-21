using System.Xml.Serialization;

namespace OpenWeather
{
    public class Visibility
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
}
