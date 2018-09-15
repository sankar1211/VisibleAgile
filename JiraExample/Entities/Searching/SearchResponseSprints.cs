using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using JiraExample.Entities.Issues;

namespace JiraExample.Entities.Searching
{
    /// <summary>
    /// A class representing a JIRA REST search response
    /// </summary>
    public class SearchResponseSprints
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("values")]
        public List<Issue> SprintDescriptions { get; set; }
    }
}
