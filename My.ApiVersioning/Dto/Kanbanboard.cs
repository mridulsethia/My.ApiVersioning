using System.Collections.Generic;

namespace My.ApiVersioning.Dto
{
	public class Kanbanboard
    {
		public Kanbanboard()
		{
			Teams = new List<Team>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Team> Teams { get; set; }
	}
}
