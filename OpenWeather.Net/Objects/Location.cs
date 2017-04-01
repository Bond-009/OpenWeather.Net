using System.Xml.Serialization;

namespace OpenWeather
{
    public class Location
    {
        [XmlElement("name")]
        public string Name { get; set; }
        // TODO: Add type
        [XmlElement("country")]
        public string Country { get; set; }
        // TODO: Add timezone

    }
}
