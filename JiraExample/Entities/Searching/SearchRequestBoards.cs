using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JiraExample.Entities.Searching
{
    /// <summary>
    /// A class representing a JIRA REST search request
    /// </summary>
    public class SearchRequestBoards
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("projectKeyOrId")]
		public string ProjectKeyOrId { get; set; }
		
    }
}
