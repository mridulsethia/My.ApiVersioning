using System.Collections.Generic;

namespace My.ApiVersioning.Dto
{
	public class Team
	{
		public Team()
		{
			Projects = new List<Project>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Project> Projects { get; set; }
	}
}
