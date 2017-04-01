using System.Xml.Serialization;

namespace OpenWeather
{
    public class Coord
    {
        [XmlAttribute("lon")]
        public double Lon { get; set; }
        [XmlAttribute("lat")]
        public double Lat { get; set; }
    }
}
