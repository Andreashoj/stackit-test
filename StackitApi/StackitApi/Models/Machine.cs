using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        public int StatusCodeId { get; set; }
        [JsonIgnore]
        public StatusCode StatusCode { get; set; }
        public DateTime StatusChanged { get; set; }
        [JsonIgnore]
        public ICollection<MachineOperator> MachineOperators { get; set; }
    }
}
