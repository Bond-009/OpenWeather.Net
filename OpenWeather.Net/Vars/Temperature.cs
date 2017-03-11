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
            switch (Unit)
            {
                case TemperatureScale.Celsius:
                    return this;
                case TemperatureScale.Kelvin:
                    return new Temperature()
                    {
                        Value = Math.Round(Value - 273.15, 2),
                        Min = Math.Round(Min - 273.15, 2),
                        Max = Math.Round(Max - 273.15, 2)
                    };
                case TemperatureScale.Fahrenheit:
                    return new Temperature()
                    {
                        Value = Math.Round(Value / 32 * 0.5556, 2),
                        Min = Math.Round(Min / 32 * 0.5556, 2),
                        Max = Math.Round(Max / 32 * 0.5556, 2)
                    };
                default:
                    throw new Exception($"Illegal enum value {Unit}");
            }
        }

        public Temperature ToKelvin()
        {
            switch (Unit)
            {
                case TemperatureScale.Kelvin:
                    return this;
                case TemperatureScale.Celsius:
                    return new Temperature()
                    {
                        Value = Math.Round(Value + 273.15, 2),
                        Min = Math.Round(Min + 273.15, 2),
                        Max = Math.Round(Max + 273.15, 2)
                    };
                case TemperatureScale.Fahrenheit:
                    return new Temperature()
                    {
                        Value = Math.Round(Value / 0.5556 * 32 + 273.15, 2),
                        Min = Math.Round(Min / 0.5556 * 32 + 273.15, 2),
                        Max = Math.Round(Max / 0.5556 * 32 + 273.15, 2)
                    };
                default:
                    throw new Exception($"Illegal enum value {Unit}");
            }
        }

        public Temperature ToFahrenheit()
        {
            switch (Unit)
            {
                case TemperatureScale.Fahrenheit:
                    return this;
                case TemperatureScale.Celsius:
                    return new Temperature()
                    {
                        Value = Math.Round(Value / 0.5556 * 32, 2),
                        Min = Math.Round(Min / 0.5556 * 32, 2),
                        Max = Math.Round(Max / 0.5556 * 32, 2)
                    };
                case TemperatureScale.Kelvin:
                    return new Temperature()
                    {
                        Value = Math.Round((Value + 273.15) / 0.5556 * 32, 2),
                        Max = Math.Round((Max + 273.15) / 0.5556 * 32, 2),
                        Min = Math.Round((Min + 273.15) / 0.5556 * 32, 2)
                    };
                default:
                    throw new Exception($"Illegal enum value {Unit}");
            }
        }
    }
}
