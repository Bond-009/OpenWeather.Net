using System;

namespace OpenWeatherNet
{
    public class Temperature
    {
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public TemperatureScale Unit { get; set; }

        public void ToCelsius()
        {
            if (Unit == TemperatureScale.Celsius) { }
            else if (Unit == TemperatureScale.Kelvin)
            {
                Value = Math.Round(Value - 273.15, 2);
                Min = Math.Round(Min - 273.15, 2);
                Max = Math.Round(Max - 273.15, 2);
                Unit = TemperatureScale.Celsius;
            }
            else if (Unit == TemperatureScale.Fahrenheit)
            {
                Value = Math.Round(Value / 32 * 0.5556, 2);
                Min = Math.Round(Min / 32 * 0.5556, 2);
                Max = Math.Round(Max / 32 * 0.5556, 2);
                Unit = TemperatureScale.Celsius;
            }
        }

        public void ToKelvin()
        {
            if (Unit == TemperatureScale.Kelvin) { }
            else if (Unit == TemperatureScale.Celsius)
            {
                Value = Math.Round(Value + 273.15, 2);
                Min = Math.Round(Min + 273.15, 2);
                Max = Math.Round(Max + 273.15, 2);
                Unit = TemperatureScale.Kelvin;
            }
            else if (Unit == TemperatureScale.Fahrenheit)
            {
                Value = Math.Round(Value / 0.5556 * 32 + 273.15, 2);
                Min = Math.Round(Min / 0.5556 * 32 + 273.15, 2);
                Max = Math.Round(Max / 0.5556 * 32 + 273.15, 2);
                Unit = TemperatureScale.Kelvin;
            }
        }

        public void ToFahrenheit()
        {
            if (Unit == TemperatureScale.Fahrenheit) { }
            else if (Unit == TemperatureScale.Celsius)
            {
                Value = Math.Round(Value / 0.5556 * 32, 2);
                Min = Math.Round(Min / 0.5556 * 32, 2);
                Max = Math.Round(Max / 0.5556 * 32, 2);
                Unit = TemperatureScale.Fahrenheit;
            }
            else if (Unit == TemperatureScale.Kelvin)
            {
                Value = Math.Round((Value + 273.15) / 0.5556 * 32, 2);
                Max = Math.Round((Max + 273.15) / 0.5556 * 32, 2);
                Min = Math.Round((Min + 273.15) / 0.5556 * 32, 2);
                Unit = TemperatureScale.Fahrenheit;
            }
        }
    }
}
