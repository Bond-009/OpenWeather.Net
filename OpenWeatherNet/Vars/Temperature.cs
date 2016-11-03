using System;

namespace OpenWeatherNet
{
	public enum TemperatureScale
	{
		Celsius,
		Fahrenheit,
		Kelvin
	}

	public class Temperature
	{
		public double value { get; set; }
		public double min { get; set; }
		public double max { get; set; }
		public TemperatureScale unit { get; set; }

		public void ToCelsius()
		{
			if (unit == TemperatureScale.Celsius) { }
			else if (unit == TemperatureScale.Kelvin)
			{
				value = Math.Round(value - 273.15, 2);
				unit = TemperatureScale.Celsius;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				value = Math.Round(value / 32 * 0.5556, 2);
				unit = TemperatureScale.Celsius;
			}
		}

		public void ToKelvin()
		{
			if (unit == TemperatureScale.Kelvin) { }
			else if (unit == TemperatureScale.Celsius)
			{
				value = Math.Round(value + 273.15, 2);
				unit = TemperatureScale.Kelvin;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				value = Math.Round(value / 0.5556 * 32 + 273.15, 2);
				unit = TemperatureScale.Kelvin;
			}
		}

		public void ToFahrenheit()
		{
			if (unit == TemperatureScale.Fahrenheit) { }
			else if (unit == TemperatureScale.Celsius)
			{
				value = Math.Round(value / 0.5556 * 32, 2);
				unit = TemperatureScale.Fahrenheit;
			}
			else if (unit == TemperatureScale.Kelvin)
			{
				value = Math.Round((value + 273.15 ) / 0.5556 * 32, 2);
				unit = TemperatureScale.Fahrenheit;
			}
		}
	}
}
