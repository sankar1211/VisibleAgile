using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using JiraExample.Entities.Misc;

namespace JiraExample.Entities.Sprints
{
    /// <summary>
    /// A class representing a project descriptin in JIRA
    /// </summary>
    public class SprintData : BaseEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
