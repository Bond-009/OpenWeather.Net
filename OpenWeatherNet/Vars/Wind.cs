namespace OpenWeatherNet
{
	public class Wind
	{
		public Wind()
		{
			speed = new Speed();
			gusts = new Gusts();
			direction = new Direction();
		}

		public Speed speed { get; set; }
		public Gusts gusts { get; set; }
		public Direction direction { get; set; }
	}
}
