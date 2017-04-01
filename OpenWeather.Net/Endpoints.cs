namespace OpenWeather
{
    internal static class Endpoints
    {
        private const string ImageEndpoint = "/img";
        public const string W = ImageEndpoint + "/w";

        private const string DataEndpoint = "/data/2.5";

        public const string Weather = DataEndpoint + "/weather";
        public const string Forecast = DataEndpoint + "/forecast";
    }
}
