using System.Xml.Serialization;

namespace OpenWeather
{
    public class Speed
    {
        /// <summary>
        /// Speed in m/s
        /// </summary>
        [XmlAttribute("value")]
        public double Value { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
