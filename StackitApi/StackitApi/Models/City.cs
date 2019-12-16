using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public ICollection<Company> Companies { get; set; }
    }
}
