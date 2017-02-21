using System;
using System.Xml.Serialization;

namespace OpenWeather
{
    public class Temperature
    {
        [XmlAttribute("value")]
        public double Value { get; set; }
        [XmlAttribute("min")]
        public double Min { get; set; }
        [XmlAttribute("max")]
        public double Max { get; set; }
        [XmlAttribute("unit")]
        public TemperatureScale Unit { get; set; }

        public Temperature ToCelsius()
        {
            Temperature celsius = this;
            if (Unit == TemperatureScale.Celsius) { return this; }
            else if (Unit == TemperatureScale.Kelvin)
            {
                celsius.Value = Math.Round(Value - 273.15, 2);
                celsius.Min = Math.Round(Min - 273.15, 2);
                celsius.Max = Math.Round(Max - 273.15, 2);
            }
            else if (Unit == TemperatureScale.Fahrenheit)
            {
                celsius.Value = Math.Round(Value / 32 * 0.5556, 2);
                celsius.Min = Math.Round(Min / 32 * 0.5556, 2);
                celsius.Max = Math.Round(Max / 32 * 0.5556, 2);
            }
            celsius.Unit = TemperatureScale.Celsius;
            return celsius;
        }

        public Temperature ToKelvin()
        {
            Temperature kelvin = this;
            if (Unit == TemperatureScale.Kelvin) { return this; }
            else if (Unit == TemperatureScale.Celsius)
            {
                kelvin.Value = Math.Round(Value + 273.15, 2);
                kelvin.Min = Math.Round(Min + 273.15, 2);
                kelvin.Max = Math.Round(Max + 273.15, 2);
            }
            else if (Unit == TemperatureScale.Fahrenheit)
            {
                kelvin.Value = Math.Round(Value / 0.5556 * 32 + 273.15, 2);
                kelvin.Min = Math.Round(Min / 0.5556 * 32 + 273.15, 2);
                kelvin.Max = Math.Round(Max / 0.5556 * 32 + 273.15, 2);
            }
            kelvin.Unit = TemperatureScale.Kelvin;
            return kelvin;
        }

        public Temperature ToFahrenheit()
        {
            Temperature fahrenheit = this;
            if (Unit == TemperatureScale.Fahrenheit) { return this; }
            else if (Unit == TemperatureScale.Celsius)
            {
                fahrenheit.Value = Math.Round(Value / 0.5556 * 32, 2);
                fahrenheit.Min = Math.Round(Min / 0.5556 * 32, 2);
                fahrenheit.Max = Math.Round(Max / 0.5556 * 32, 2);
            }
            else if (Unit == TemperatureScale.Kelvin)
            {
                fahrenheit.Value = Math.Round((Value + 273.15) / 0.5556 * 32, 2);
                fahrenheit.Max = Math.Round((Max + 273.15) / 0.5556 * 32, 2);
                fahrenheit.Min = Math.Round((Min + 273.15) / 0.5556 * 32, 2);
            }
            fahrenheit.Unit = TemperatureScale.Fahrenheit;
            return fahrenheit;
        }
    }
}
