namespace My.ApiVersioning.Dto
{
	public class ComplexObject
    {
		public ComplexObject()
		{
			Name = string.Empty;
		}
		public string Name { get; set; }
		public Wall Wall { get; set; }
	}
}
