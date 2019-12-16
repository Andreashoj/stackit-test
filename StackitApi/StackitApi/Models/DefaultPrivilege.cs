using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class DefaultPrivilege
    {
        public int UserTypeId { get; set; }
        [JsonIgnore]
        public UserType UserType { get; set; }
        public int PrivilegeId { get; set; }
        [JsonIgnore]
        public Privilege Privilege { get; set; }
    }
}
