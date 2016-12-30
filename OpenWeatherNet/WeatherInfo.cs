using System;

namespace OpenWeatherNet
{	/// <summary>
	/// Info about the weather
	/// </summary>
	public class WeatherInfo
	{
		public WeatherInfo()
		{
			city = new City();
			temperature = new Temperature();
			humidity = new Humidity();
			pressure = new Pressure();
			wind = new Wind();
			clouds = new Clouds();
			precipitation = new Precipitation();
			weather = new Weather();
		}

		public City city { get; set; }
		public Temperature temperature { get; set; }
		public Humidity humidity { get; set; }
		public Pressure pressure { get; set; }
		public Wind wind { get; set; }
		public Clouds clouds { get; set; }
		//TODO: Add visibility
		public Precipitation precipitation { get; set; }
		public Weather weather { get; set; }
		/// <summary>
		/// URL to the icon
		/// </summary>
		public string iconURL { get; set; }
		public DateTime lastupdate { get; set; }
	}
}
