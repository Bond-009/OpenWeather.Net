namespace OpenWeather
{
    public class Wind
    {
        public Speed Speed { get; set; } = new Speed();
        public Gusts Gusts { get; set; } = new Gusts();
        public Direction Direction { get; set; } = new Direction();
    }
}
