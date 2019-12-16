using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class UserPrivilege
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int PrivilegeId { get; set; }
        [JsonIgnore]
        public Privilege Privilege { get; set; }
    }
}
