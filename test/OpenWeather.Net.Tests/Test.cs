using System;
using System.IO;
using Xunit;

namespace OpenWeather.Tests
{
    public class Test : IDisposable
    {
        OpenWeatherClient client;

        public Test()
        {
            client = new OpenWeatherClient(File.ReadAllLines(AppContext.BaseDirectory + Path.DirectorySeparatorChar + "key.txt")[0]);
        }

        [Fact]
        public void WeatherTest()
        {
            WeatherInfo info =  client.GetWeatherAsync("London", "uk").GetAwaiter().GetResult();
            Console.WriteLine($"City: {info.City.Name}, {info.City.Country}" + Environment.NewLine +
                $"Icon url: {client.GetIconURL(info.Weather.Icon)}");
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
