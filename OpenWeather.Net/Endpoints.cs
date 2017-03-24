namespace OpenWeather
{
    internal static class Endpoints
    {
        // REVIEW: 
        public const string BaseUrl = "http://api.openweathermap.org";

        public const string ImageEndpoint = BaseUrl + "/img";
        public const string W = ImageEndpoint + "/w";

        public const string DataEndpoint = BaseUrl + "/data/2.5";

        public const string Weather = DataEndpoint + "/weather";
    }
}
