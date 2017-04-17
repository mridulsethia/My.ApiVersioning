
namespace My.ApiVersioning.Models
{
	public class ValueModel
    {
		public Dto.Kanbanboard Values
		{
			get
			{
				var board = new Dto.Kanbanboard { Title = "Kanbanboard 1" };
				var team = new Dto.Team { Name = "Team 1" };
				var project = new Dto.Project { Name = "Pilot App", Client="XYZ", Priority=10 };
				var release = new Dto.Release { Name = "R1", Date = "2017-04-10" };
				release.Tasks.Add(new Dto.Task { Title = "Task 1", Description = "Description for task 1", Status = "Done", Priority = 5, Started = "2017-03-01", Finished = "2017-03-10" });
				release.Tasks.Add(new Dto.Task { Title = "Task 2", Description = "Description for task 2", Status = "Blocked", Priority = 4, Started = "2017-03-15", Finished = null });
				release.Tasks.Add(new Dto.Task { Title = "Task 3", Description = "Description for task 3", Status = "InProgress", Priority = 3, Started = "2017-03-17", Finished = null });
				release.Tasks.Add(new Dto.Task { Title = "Task 4", Description = "Description for task 4", Status = "Backlog", Priority = 2, Started = null, Finished = null });
				project.Releases.Add(release);
				team.Projects.Add(project);

				var project1 = new Dto.Project { Name = "Sprint 2", Client = "XYZ", Priority = 9 };
				var release1 = new Dto.Release { Name = "R2", Date = "2017-05-10" };
				release1.Tasks.Add(new Dto.Task { Title = "Task 5", Description = "Description for task 5", Status = "Backlog", Priority =4, Started = null, Finished = null });
				project1.Releases.Add(release1);
				team.Projects.Add(project1);

				var project2 = new Dto.Project { Name = "Pre Analysis", Client = "ABC", Priority = 8 };
				var release2 = new Dto.Release { Name = "R1", Date = "2017-05-30" };
				release2.Tasks.Add(new Dto.Task { Title = "Task 1", Description = "Description for task 1", Status = "Backlog", Priority = 10, Started = null, Finished = null });
				project2.Releases.Add(release2);
				team.Projects.Add(project2);

				board.Teams.Add(team);
				return board;
			}
		}
	}
}
