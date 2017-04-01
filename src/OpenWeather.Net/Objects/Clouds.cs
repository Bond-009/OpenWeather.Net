using System.Xml.Serialization;

namespace OpenWeather
{
    public class Clouds
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
