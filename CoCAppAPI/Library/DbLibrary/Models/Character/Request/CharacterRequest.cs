using DbLibrary.Models.Characteristic.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Character.Request
{
    public class CharacterRequest
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GameId { get; set; }
        public List<CharacteristicRequest> Characteristics { get; set; }
    }
}
