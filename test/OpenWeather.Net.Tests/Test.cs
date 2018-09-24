using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeather.Tests
{
    public class Test : IDisposable
    {
        OpenWeatherClient client = new OpenWeatherClient(Environment.GetEnvironmentVariable("OPENWEATHERMAPKEY"), Unit.Metric);

        [Fact]
        public async Task WeatherTest()
        {
            WeatherData info = await client.GetWeatherAsync("London", "uk");
            if (!Uri.IsWellFormedUriString(client.GetIconURL(info.Weather.FirstOrDefault()?.Icon), UriKind.Absolute))
            {
                throw new Exception("Not a valid icon URL");
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
