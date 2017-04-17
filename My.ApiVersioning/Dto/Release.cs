using System.Collections.Generic;

namespace My.ApiVersioning.Dto
{
	public class Release
	{
		public Release()
		{
			Tasks = new List<Task>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Date { get; set; }
		public List<Task> Tasks { get; set; }
	}
}
