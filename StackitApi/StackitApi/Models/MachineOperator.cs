using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class MachineOperator
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int MachineId { get; set; }
        [JsonIgnore]
        public Machine Machine { get; set; }
    }
}
