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
		public double Value { get; set; }
		public double Min { get; set; }
		public double Max { get; set; }
		public TemperatureScale unit { get; set; }

		public void ToCelsius()
		{
			if (unit == TemperatureScale.Celsius) { }
			else if (unit == TemperatureScale.Kelvin)
			{
				Value = Math.Round(Value - 273.15, 2);
				Min = Math.Round(Min - 273.15, 2);
				Max = Math.Round(Max - 273.15, 2);
				unit = TemperatureScale.Celsius;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				Value = Math.Round(Value / 32 * 0.5556, 2);
				Min = Math.Round(Min / 32 * 0.5556, 2);
				Max = Math.Round(Max / 32 * 0.5556, 2);
				unit = TemperatureScale.Celsius;
			}
		}

		public void ToKelvin()
		{
			if (unit == TemperatureScale.Kelvin) { }
			else if (unit == TemperatureScale.Celsius)
			{
				Value = Math.Round(Value + 273.15, 2);
				Min = Math.Round(Min + 273.15, 2);
				Max = Math.Round(Max + 273.15, 2);
				unit = TemperatureScale.Kelvin;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				Value = Math.Round(Value / 0.5556 * 32 + 273.15, 2);
				Min = Math.Round(Min / 0.5556 * 32 + 273.15, 2);
				Max = Math.Round(Max / 0.5556 * 32 + 273.15, 2);
				unit = TemperatureScale.Kelvin;
			}
		}

		public void ToFahrenheit()
		{
			if (unit == TemperatureScale.Fahrenheit) { }
			else if (unit == TemperatureScale.Celsius)
			{
				Value = Math.Round(Value / 0.5556 * 32, 2);
				Min = Math.Round(Min / 0.5556 * 32, 2);
				Max = Math.Round(Max / 0.5556 * 32, 2);
				unit = TemperatureScale.Fahrenheit;
			}
			else if (unit == TemperatureScale.Kelvin)
			{
				Value = Math.Round((Value + 273.15 ) / 0.5556 * 32, 2);
				Max = Math.Round((Max + 273.15) / 0.5556 * 32, 2);
				Min = Math.Round((Min + 273.15) / 0.5556 * 32, 2);
				unit = TemperatureScale.Fahrenheit;
			}
		}
	}
}
