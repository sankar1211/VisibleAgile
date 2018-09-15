using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiraExample.Entities.Projects;
using JiraExample.Entities.Issues;
using JiraExample.Entities.Boards;
using JiraExample.Entities.Sprints;

namespace JiraExample
{
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello and welcome to a Jira Example application!");

		Console.Write("Enter Base URL <Default: https://visibleagile.atlassian.net/> :");
		string baseUrl = Console.ReadLine();

		if (baseUrl.Trim().Length == 0)
			baseUrl = "https://visibleagile.atlassian.net/";
	
		#region Create manager
		Console.Write("Username: <Default: sankar72@outlook.com>");
        string username = Console.ReadLine();

		if (username.Trim().Length == 0)
			username = "sankar72@outlook.com";

		Console.Write("Password: ");
        string password = Console.ReadLine();

		if (username.Trim().Equals("sankar72@outlook.com") == true)
			password = "ABHI123$";

		JiraManager manager = new JiraManager(baseUrl, username, password);
		#endregion

		Console.Clear();
			
		// Get List of Boards
		BoardsDescription bd = manager.GetBoards(baseUrl);
		List <BoardsData> boards = bd.Values;

		if (boards.Count == 0)
		{
			Console.WriteLine("No Boards created yet");
			return;
		}

		Console.WriteLine("Select a Board: ");

		for (int i = 0; i < boards.Count; i++)
		{
			Console.WriteLine("{0}: {1}", i, boards[i].Name);
		}

		Console.Write("Boards to open: ");

		string boardsStringIndex = Console.ReadLine();
		int boardIndex = 0;
		if (!int.TryParse(boardsStringIndex, out boardIndex))
		{
			Console.WriteLine("You failed to select a board...");
			Environment.Exit(0);
		}

		BoardsData selectedBoard = boards[boardIndex];

			if (selectedBoard.Type.Equals("scrum"))
			{

				SprintsDescription sprintsDescription = manager.GetSprints(selectedBoard.Id);

				List<SprintData> sprints = sprintsDescription.Values;

				if (sprints.Count != 0)
				{
					for (int i = 0; i < sprints.Count; i++)
					{
						int numIssues = manager.GetNumIssues(selectedBoard.Id, sprints[i].Id);
						Console.WriteLine("Number of issues in Sprint " + sprints[i].Id + ": " + sprints[i].Name + " are " + numIssues);
					}
					
				}
				else
				{
					Console.WriteLine("No Sprints created yet");
									}

				
			}
			else
			{
				Console.WriteLine("Does Not support Non-scrum");
			}
		Console.Read();
    }
}
}
