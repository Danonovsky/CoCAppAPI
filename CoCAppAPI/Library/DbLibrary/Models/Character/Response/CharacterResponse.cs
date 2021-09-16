using DbLibrary.Models.Characteristic.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Character.Response
{
    public class CharacterResponse
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public List<CharacteristicResponse> Characteristics { get; set; }
    }
}
