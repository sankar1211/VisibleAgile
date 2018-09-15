using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using JiraExample.Entities.Projects;
using JiraExample.Entities.Boards;
using Newtonsoft.Json;
using JiraExample.Entities.Issues;
using JiraExample.Entities.Searching;
using JiraExample.Entities.Sprints;

namespace JiraExample
{
    public class JiraManager
    {
		// private const string m_BaseUrl = "https://visibleagile.atlassian.net/rest/api/latest/";
		private string m_BaseUrl;
		private string m_Username;
        private string m_Password;

        public JiraManager(String baseUrl, string username, string password)
        {
			m_BaseUrl = baseUrl;
			m_Username = username;
            m_Password = password;
        }

        /// <summary>
        /// Runs a query towards the JIRA REST api
        /// </summary>
        /// <param name="resource">The kind of resource to ask for</param>
        /// <param name="argument">Any argument that needs to be passed, such as a project key</param>
        /// <param name="data">More advanced data sent in POST requests</param>
        /// <param name="method">Either GET or POST</param>
        /// <returns></returns>
        protected string RunQuery(            
            string argument = null, 
            string data = null,
            string method = "GET")
        {
            string url = "";

            if (argument != null)
            {
                url = string.Format("{0}{1}/", m_BaseUrl, argument);
            }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = method;

            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }

            string base64Credentials = GetEncodedCredentials();
            request.Headers.Add("Authorization", "Basic " + base64Credentials);

			HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))           
{
            result = reader.ReadToEnd();
            }

            return result;
        }
		
		
		public BoardsDescription GetBoards(string baseUrl,
			string type = "scrum",
			string name = null,
			int startAt = 0,
			int maxResult = 50)
		{
			SearchRequestBoards request = new SearchRequestBoards();

			request.Name = name;
			request.ProjectKeyOrId = "VATT";
			request.MaxResults = maxResult;
			request.StartAt = startAt;
			request.Type = type;

			string data = JsonConvert.SerializeObject(request);
			string extUrl = "rest/agile/1.0/board";
			//string result = RunQueryBoard();
			string result = RunQuery(extUrl);

			return JsonConvert.DeserializeObject<BoardsDescription>(result);
		}

		public SprintsDescription GetSprints(
			int boardId,
			string state = "active",
			List<string> fields = null,
			int startAt = 0,
			int maxResult = 50)
		{
			SearchRequestBoards request = new SearchRequestBoards();

			//request.ProjectKeyOrId = "VATT";
			request.MaxResults = maxResult;
			request.StartAt = startAt;

			string data = JsonConvert.SerializeObject(request);

			
			string extUrl = "rest/agile/1.0/board/";

			string argument = string.Format("{0}{1}{2}", extUrl, boardId, "/sprint");
			//string result = RunQueryBoard();
			string result = RunQuery(argument);

			return JsonConvert.DeserializeObject<SprintsDescription>(result);
		}

		public int GetNumIssues(
			int boardId,
			int sprintId,
			string state = "active",
			List<string> fields = null,
			int startAt = 0,
			int maxResult = 50)
		{
			SearchRequestBoards request = new SearchRequestBoards();

			request.ProjectKeyOrId = "VATT";
			request.MaxResults = maxResult;
			request.StartAt = startAt;

			string data = JsonConvert.SerializeObject(request);


			string extUrl = "rest/agile/1.0/board/";

			string argument = string.Format("{0}{1}{2}{3}{4}/", extUrl, boardId, "/sprint/", sprintId, "/issue/");
			//string result = RunQueryBoard();
			string result = RunQuery(argument);

			IssueDescription issueDescription =  JsonConvert.DeserializeObject<IssueDescription>(result);
			return issueDescription.Total;
		}
		private string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", m_Username, m_Password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }

		
    }
}
