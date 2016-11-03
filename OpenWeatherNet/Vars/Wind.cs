namespace OpenWeatherNet
{
	public class Wind
	{
		public Speed speed { get; set; } = new Speed();
		public Gusts gusts { get; set; } = new Gusts();
		public Direction direction { get; set; } = new Direction();
	}
}
