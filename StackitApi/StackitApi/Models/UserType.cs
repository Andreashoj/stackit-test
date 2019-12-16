using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IList<DefaultPrivilege> DefaultPrivileges { get; set; }
        [JsonIgnore]
        public IList<User> Users { get; set; }
    }
}
