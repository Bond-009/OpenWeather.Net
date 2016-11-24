using System;

namespace OpenWeatherNet
{
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

		public string iconLocation { get; set; }
		//public Bitmap icon { get; set; }
		public DateTime lastupdate { get; set; }
	}
}
