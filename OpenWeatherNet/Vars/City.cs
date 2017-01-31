namespace OpenWeatherNet
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; } = new Coord();
        public string Country { get; set; }
        public Sun Sun { get; set; } = new Sun();
    }
}
