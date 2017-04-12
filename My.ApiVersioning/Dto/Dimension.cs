namespace My.ApiVersioning.Dto
{
	public class Dimension
    {
		public double Height { get; set; }
		public double Width { get; set; }
		public double Depth { get; set; }
	}
	public class Wall
	{
		public Dimension Dimension { get; set; }
	}
}
