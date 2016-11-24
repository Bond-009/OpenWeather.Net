namespace OpenWeatherNet
{
	public class City
	{
		public City()
		{
			coord = new Coord();
			sun = new Sun();
		}

		public int id { get; set; }
		public string name { get; set; }
		public Coord coord { get; set; }
		public string country { get; set; }
		public Sun sun { get; set; }
	}
}