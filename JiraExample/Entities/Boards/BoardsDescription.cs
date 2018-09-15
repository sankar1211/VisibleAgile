using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using JiraExample.Entities.Misc;

namespace JiraExample.Entities.Boards
{
    /// <summary>
    /// A class representing a project descriptin in JIRA
    /// </summary>
    public class BoardsDescription : BaseEntity
    {

		/*[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("avatarUrls")]
		public AvatarUrls AvatarUrls { get; set; } */


		[JsonProperty("startAt")]
		public int StartAt { get; set; }

		[JsonProperty("maxResults")]
		public int MaxResults { get; set; }

		//[JsonProperty("values")]
		//public string Values { get; set; }

		[JsonProperty("values")]
		public List<BoardsData> Values { get; set; }

		public BoardsDescription()
		{
			Values = new List<BoardsData>();
		}

	}
}
