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
		public double value { get; internal set; }
		public double min { get; internal set; }
		public double max { get; internal set; }
		public TemperatureScale unit { get; internal set; }

		public void ToCelsius()
		{
			if (unit == TemperatureScale.Celsius) { }
			else if (unit == TemperatureScale.Kelvin)
			{
				value = value - 273.15;
				unit = TemperatureScale.Celsius;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				value = value / 32 * 0.5556;
				unit = TemperatureScale.Celsius;
			}
		}

		public void ToKelvin()
		{
			if (unit == TemperatureScale.Kelvin) { }
			else if (unit == TemperatureScale.Celsius)
			{
				value = value + 273.15;
				unit = TemperatureScale.Kelvin;
			}
			else if (unit == TemperatureScale.Fahrenheit)
			{
				value = value / 0.5556 * 32 + 273.15;
				unit = TemperatureScale.Kelvin;
			}
		}

		public void ToFahrenheit()
		{
			if (unit == TemperatureScale.Fahrenheit) { }
			else if (unit == TemperatureScale.Celsius)
			{
				value = value / 0.5556 * 32;
				unit = TemperatureScale.Fahrenheit;
			}
			else if (unit == TemperatureScale.Kelvin)
			{
				value = (value + 273.15 ) / 0.5556 * 32;
				unit = TemperatureScale.Fahrenheit;
			}
		}
	}
}
