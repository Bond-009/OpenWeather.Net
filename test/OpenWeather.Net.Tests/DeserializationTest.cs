using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeather.Tests
{
    public class DeserializationTest
    {
        [Theory]
        [InlineData("NewYork.json")]
        [InlineData("Sydney.json")]
        public async Task Deserialize_Success(string resource)
        {
            using (Stream stream = File.OpenRead("TestFiles/" + resource))
            {
                await JsonSerializer.DeserializeAsync<WeatherData>(stream).ConfigureAwait(false);
            }
        }

        [Fact]
        public async Task Deserialize_London_Success()
        {
            using Stream stream = File.OpenRead("TestFiles/London.json");
            var data = await JsonSerializer.DeserializeAsync<WeatherData>(stream).ConfigureAwait(false);
            Assert.Equal(new DateTimeOffset(2019, 7, 2, 3, 47, 56, TimeSpan.Zero), data.Sys.Sunrise);
            Assert.Equal(new DateTimeOffset(2019, 7, 2, 20, 20, 44, TimeSpan.Zero), data.Sys.Sunset);
        }
    }
}
