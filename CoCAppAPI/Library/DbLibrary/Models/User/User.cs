using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DbLibrary.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Nickname { get; set; }
    }
}
