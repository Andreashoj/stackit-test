using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileLocation { get; set; }
        public DateTime UploadedTime { get; set; }
        public string FileType { get; set; }
        [JsonIgnore]
        public ICollection<JobFile> JobFiles { get; set; }
    }
}
