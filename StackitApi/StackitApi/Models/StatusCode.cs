using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class StatusCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        [JsonIgnore]
        public ICollection<Machine> Machines { get; set; }
    }
}
