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
    public class BoardsData : BaseEntity
    {

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

	
	}
}
