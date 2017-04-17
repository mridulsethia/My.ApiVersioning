using My.ApiVersioning.Dto;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace My.ApiVersioning.Public
{
	public class ValueModelV2 : Models.ValueModel
    {
		// Manually build the public API structure to assure that this version is not affected when the modle evolves and new versions are published 
		public new dynamic Values
		{
			get
			{
				var data = base.Values;
				//dynamic expando = Common.Helper.ToDynamic(data); // you can choose to return the current data structure together with the old structure
				dynamic expando = new ExpandoObject();
				expando.clients = GetAllClients(data.Teams); //NOTE: Expando property names are rendered AS IS! camelCase property names manually !!
				return expando;
			}
		}

		private dynamic GetAllClients(IEnumerable<Team> teams)
		{
			var clientList = new List<ExpandoObject>();
			foreach (var team in teams)
			{
				var clients = team.Projects.GroupBy(p => p.Client).Select(c => c.First().Client);
				foreach (var clientName in clients)
				{
					clientList.Add(GetClient(team, clientName));
				}
			}
			return clientList;
		}

		private dynamic GetClient(Team team, string clientName)
		{
			dynamic client = new ExpandoObject();
			client.name = clientName;
			client.team = team.Name;
			var projects = new List<ExpandoObject>();
			foreach (var project in team.Projects.Where(c => c.Client.Equals(clientName)))
			{
				projects.Add(GetProject(project));
			}
			client.projects = projects;
			return client;
		}

		private dynamic GetProject(Project project)
		{
			dynamic proj = new ExpandoObject();
			proj.name = project.Name;
			var tasks = new List<List<string>>();
			foreach (var release in project.Releases)
			{
				foreach (var task in release.Tasks)
				{
					tasks.Add(new List<string> { release.Date, task.Title, task.Status });
				}
			}
			proj.tasks = tasks;
			return proj;
		}
	}
}
