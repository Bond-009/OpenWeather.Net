namespace OpenWeatherNet
{
	public class Wind
	{
		public Wind()
		{
			Speed = new Speed();
			Gusts = new Gusts();
			Direction = new Direction();
		}

		public Speed Speed { get; set; }
		public Gusts Gusts { get; set; }
		public Direction Direction { get; set; }
	}
}
