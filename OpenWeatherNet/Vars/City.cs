namespace OpenWeatherNet
{
	public class City
	{
		public int id { get; internal set; }
		public string name { get; internal set; }
		public Coord coord = new Coord();
		public string country { get; internal set; }
		public Sun sun = new Sun();
	}
}
