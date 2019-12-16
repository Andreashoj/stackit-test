using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class Privilege
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public IList<UserPrivilege> UserPrivileges { get; set; }
        [JsonIgnore]
        public IList<DefaultPrivilege> DefaultPrivileges { get; set; }
    }
}
