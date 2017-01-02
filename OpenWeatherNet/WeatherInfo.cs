using System;

namespace OpenWeatherNet
{	/// <summary>
	/// Info about the weather
	/// </summary>
	public class WeatherInfo
	{
		public WeatherInfo()
		{
			City = new City();
			Temperature = new Temperature();
			Humidity = new Humidity();
			Pressure = new Pressure();
			Wind = new Wind();
			Clouds = new Clouds();
			Precipitation = new Precipitation();
			Weather = new Weather();
		}

		public City City { get; set; }
		public Temperature Temperature { get; set; }
		public Humidity Humidity { get; set; }
		public Pressure Pressure { get; set; }
		public Wind Wind { get; set; }
		public Clouds Clouds { get; set; }
		//TODO: Add visibility
		public Precipitation Precipitation { get; set; }
		public Weather Weather { get; set; }
		/// <summary>
		/// URL to the icon
		/// </summary>
		public string IconURL { get; set; }
		public DateTime Lastupdate { get; set; }
	}
}
