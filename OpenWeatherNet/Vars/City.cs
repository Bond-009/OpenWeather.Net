namespace OpenWeatherNet
{
	public class City
	{
		public City()
		{
			Coord = new Coord();
			Sun = new Sun();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Coord Coord { get; set; }
		public string Country { get; set; }
		public Sun Sun { get; set; }
	}
}