namespace My.ApiVersioning.Dto
{
	public class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Priority { get; set; }
		public string Status { get; set; }
		public string Started { get; set; }
		public string Finished { get; set; }
	}
}
