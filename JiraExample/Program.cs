using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiraExample.Entities.Projects;
using JiraExample.Entities.Issues;

namespace JiraExample
{
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello and welcome to a Jira Example application!");

		Console.Write("Enter Base URL <Default: https://visibleagile.atlassian.net/rest/api/latest/");
		string baseUrl = Console.ReadLine();

		if(baseUrl.Trim().Length == 0)
			baseUrl = "https://visibleagile.atlassian.net/rest/api/latest/";

		#region Create manager
		Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        JiraManager manager = new JiraManager(baseUrl, username, password);
        #endregion

        Console.Clear();

        List<ProjectDescription> projects = manager.GetProjects();
        Console.WriteLine("Select a project: ");
        for (int i = 0; i < projects.Count; i++)
        {
            Console.WriteLine("{0}: {1}", i, projects[i].Name);
        }

        Console.Write("Project to open: ");
        string projectStringIndex = Console.ReadLine();
        int projectIndex = 0;
        if (!int.TryParse(projectStringIndex, out projectIndex))
        {
            Console.WriteLine("You failed to select a project...");
            Environment.Exit(0);
        }

        ProjectDescription selectedProject = projects[projectIndex];
        string projectKey = selectedProject.Key;

        string jql = "project = " + projectKey;
        List<Issue> issueDescriptions = manager.GetIssues(jql);
        string name = "";
        foreach (Issue description in issueDescriptions)
        {
                if (description.Fields.Assignee == null)
                    name = "Not Assigned";
                else
                    name = description.Fields.Assignee.DisplayName;

           Console.WriteLine("{0}: {1}: {2}", description.Key, description.Fields.Summary, name);
        }

        

        Console.Read();
    }
}
}
