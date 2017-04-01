using System.Xml.Serialization;

namespace OpenWeather
{
    public enum TemperatureScale
    {
        [XmlEnum("celsuis")]
        Celsius,
        [XmlEnum("fahrenheit")]
        Fahrenheit,
        [XmlEnum("kelvin")]
        Kelvin
    }
}
