using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StackitApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        [JsonIgnore]
        public UserType UserType { get; set; }
        public int CompanyId { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActivity { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public ICollection<MachineOperator> MachineOperators { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
