using System;
using System.Xml.Serialization;

namespace OpenWeather
{
    public class Sun
    {
        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }
        [XmlAttribute("set")]
        public DateTime Set { get; set; }
    }
}
