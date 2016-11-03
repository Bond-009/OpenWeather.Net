namespace OpenWeatherNet
{
	public class City
	{
		public int id { get; set; }
		public string name { get; set; }
		public Coord coord { get; set; } = new Coord();
		public string country { get; set; }
		public Sun sun { get; set; } = new Sun();
	}
}
