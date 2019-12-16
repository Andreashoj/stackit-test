using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class Stack
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        [JsonIgnore]
        public Machine Machine { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsFinished { get; set; }
        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
    }
}
