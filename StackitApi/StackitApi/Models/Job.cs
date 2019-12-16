using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int StackId { get; set; }
        [JsonIgnore]
        public Stack Stack { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime EstimatedTime { get; set; }
        public DateTime StartedTime { get; set; }
        [JsonIgnore]
        public ICollection<JobFile> JobFiles { get; set; }
    }
}
