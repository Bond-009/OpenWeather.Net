using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeather
{
    public class OpenWeatherClient
    {
        public OpenWeatherClient(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// OpenWeatherMap api key
        /// </summary>
        public string ApiKey { get; set; }

        HttpClient httpclient1 = new HttpClient();

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(string cityName)
        {
            return await GetWeatherAsync($"{Endpoints.DataEndpoint}{Endpoints.Weather}?q={cityName}&appid={ApiKey}&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetCurrentAsync(Coord coords)
        {
            return await GetWeatherAsync($"{Endpoints.DataEndpoint}{Endpoints.Weather}?lat={coords.Lat}&lon={coords.Lon}&appid={ApiKey}&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(double lat, double lon)
        {
            return await GetWeatherAsync($"{Endpoints.DataEndpoint}{Endpoints.Weather}?lat={lat}&lon={lon}&appid={ApiKey}&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(int zipCode, string countryCode)
        {
            return await GetWeatherAsync($"{Endpoints.DataEndpoint}{Endpoints.Weather}?zip={zipCode},{countryCode}&appid={ApiKey}&mode=xml");
        }

        /// <summary>
        /// Gets the url for the icon
        /// </summary>
        /// <param name="icon">icon</param>
        /// <returns>Url to the icon</returns>
		public string GetIconURL(string icon)
        {
            return Endpoints.ImageEndpoint + Endpoints.W + "/" + icon + ".png";
        }

        private async Task<WeatherInfo> GetWeatherAsync(string url)
        {
            using (Stream stream = await httpclient1.GetStreamAsync(url))
            {
                return (WeatherInfo)new XmlSerializer(typeof(WeatherInfo)).Deserialize(stream);
            }
        }
    }
}
