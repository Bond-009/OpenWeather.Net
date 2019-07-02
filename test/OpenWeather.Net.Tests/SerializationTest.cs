using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeather.Tests
{
    public class SerializationTest
    {
        [Theory]
        [InlineData("London.json")]
        [InlineData("NewYork.json")]
        [InlineData("Sydney.json")]
        public async ValueTask Test(string resource)
        {
            using (Stream stream = typeof(SerializationTest).Assembly
                .GetManifestResourceStream("OpenWeather.Net.Tests/TestFiles/" + resource))
            {
                await JsonSerializer.DeserializeAsync<WeatherData>(stream).ConfigureAwait(false);
            }
        }
    }
}
