using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class JobFile
    {
        public int JobId { get; set; }
        [JsonIgnore]
        public Job Job { get; set; }
        public int FileId { get; set; }
        [JsonIgnore]
        public File File { get; set; }
    }
}
