﻿using System;
using System.Xml;

namespace OpenWeatherNet
{
	public class WeatherInfo
	{
		internal WeatherInfo(string url)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(url);

			city.id = Convert.ToInt32(xmlDoc.SelectSingleNode("current/city").Attributes["id"].InnerText);
			city.name = xmlDoc.SelectSingleNode("current/city").Attributes["name"].InnerText;
			city.coord.lon = Convert.ToDouble(xmlDoc.SelectSingleNode("current/city/coord").Attributes["lon"].InnerText);
			city.coord.lat = Convert.ToDouble(xmlDoc.SelectSingleNode("current/city/coord").Attributes["lat"].InnerText);
			city.country = xmlDoc.SelectSingleNode("current/city/country").InnerText;
			city.sun.rise = Convert.ToDateTime(xmlDoc.SelectSingleNode("current/city/sun").Attributes["rise"].InnerText);
			city.sun.set = Convert.ToDateTime(xmlDoc.SelectSingleNode("current/city/sun").Attributes["set"].InnerText);

			temperature.value = Convert.ToDouble(xmlDoc.SelectSingleNode("current/temperature").Attributes["value"].InnerText);
			temperature.min = Convert.ToDouble(xmlDoc.SelectSingleNode("current/temperature").Attributes["min"].InnerText);
			temperature.max = Convert.ToDouble(xmlDoc.SelectSingleNode("current/temperature").Attributes["max"].InnerText);
			temperature.unit = xmlDoc.SelectSingleNode("current/temperature").Attributes["unit"].InnerText;

			humidity.value = Convert.ToInt32(xmlDoc.SelectSingleNode("current/humidity").Attributes["value"].InnerText);
			humidity.unit = xmlDoc.SelectSingleNode("current/humidity").Attributes["unit"].InnerText;

			pressure.value = Convert.ToDouble(xmlDoc.SelectSingleNode("current/pressure").Attributes["value"].InnerText);
			pressure.unit = xmlDoc.SelectSingleNode("current/pressure").Attributes["unit"].InnerText;

			wind.speed.value = Convert.ToDouble(xmlDoc.SelectSingleNode("current/wind/speed").Attributes["value"].InnerText);
			wind.speed.name = xmlDoc.SelectSingleNode("current/wind/speed").Attributes["name"].InnerText;

			//TODO: Add gusts if (xmlDoc.SelectSingleNode("current/wind/gusts").HasChildNodes) { gusts_TextBox.Text = xmlDoc.SelectSingleNode("current/wind/gusts").Attributes["value"].InnerText + "m/s"; }

			wind.direction.value = Convert.ToDouble(xmlDoc.SelectSingleNode("current/wind/direction").Attributes["value"].InnerText);
			wind.direction.code = xmlDoc.SelectSingleNode("current/wind/direction").Attributes["code"].InnerText;
			wind.direction.name = xmlDoc.SelectSingleNode("current/wind/direction").Attributes["name"].InnerText;

			clouds.value = Convert.ToInt32(xmlDoc.SelectSingleNode("current/clouds").Attributes["value"].InnerText);
			clouds.name = xmlDoc.SelectSingleNode("current/clouds").Attributes["name"].InnerText;

			//TODO: Add visibility

			if (xmlDoc.SelectSingleNode("current/precipitation").Attributes["value"] != null)
			{
				precipitation.value = Convert.ToDouble(xmlDoc.SelectSingleNode("current/precipitation").Attributes["value"].InnerText);
			}
			precipitation.mode = xmlDoc.SelectSingleNode("current/precipitation").Attributes["mode"].InnerText;
			if (xmlDoc.SelectSingleNode("current/precipitation").Attributes["unit"] != null)
			{
				precipitation.unit = xmlDoc.SelectSingleNode("current/precipitation").Attributes["unit"].InnerText;
			}

			weather.number = Convert.ToInt32(xmlDoc.SelectSingleNode("current/weather").Attributes["number"].InnerText);
			weather.value = xmlDoc.SelectSingleNode("current/weather").Attributes["value"].InnerText;
			weather.icon = xmlDoc.SelectSingleNode("current/weather").Attributes["icon"].InnerText;
			iconLocation = "http://openweathermap.org/img/w/" + weather.icon + ".png";
			//TODO: Add icon

			lastupdate = Convert.ToDateTime(xmlDoc.SelectSingleNode("current/lastupdate").Attributes["value"].InnerText);
		}

		public City city { get; internal set; } = new City();
		public Temperature temperature { get; internal set; } = new Temperature();
		public Humidity humidity { get; internal set; } = new Humidity();
		public Pressure pressure { get; internal set; } = new Pressure();
		public Wind wind { get; internal set; } = new Wind();
		public Clouds clouds { get; internal set; } = new Clouds();
		//TODO: Add visibility
		public Precipitation precipitation { get; internal set; } = new Precipitation();
		public Weather weather { get; internal set; } = new Weather();

		public static string iconLocation { get; internal set; }
		//public static Bitmap icon { get; internal set; }
		public static DateTime lastupdate { get; internal set; }
	}
}
