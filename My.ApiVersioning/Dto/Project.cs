using System.Collections.Generic;

namespace My.ApiVersioning.Dto
{
	public class Project
	{
		public Project()
		{
			Releases = new List<Release>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Client { get; set; }
		public int Priority { get; set; }
		public List<Release> Releases { get; set; }
	}
}