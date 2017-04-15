using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeather.Tests
{
    public class Test : IDisposable
    {
        OpenWeatherClient client = new OpenWeatherClient(
            File.ReadAllLines(AppContext.BaseDirectory + Path.DirectorySeparatorChar + "key.txt")[0]);

        [Fact]
        public async Task WeatherTest()
        {
            WeatherInfo info = await client.GetWeatherAsync("London", "uk");
            if (!Uri.IsWellFormedUriString(client.GetIconURL(info.Weather.Icon), UriKind.Absolute))
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
