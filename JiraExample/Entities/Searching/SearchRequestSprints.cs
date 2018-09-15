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
    public class SearchRequestSprints
    {
        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

		[JsonProperty("fields")]
		public List<string> Fields { get; set; }

		public SearchRequestSprints()
		{
			Fields = new List<string>();
		}

	}
}
