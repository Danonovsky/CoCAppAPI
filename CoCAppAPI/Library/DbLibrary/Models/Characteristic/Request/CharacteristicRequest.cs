using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Characteristic.Request
{
    public class CharacteristicRequest
    {
        public Guid DefaultCharacteristicId { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }
    }
}
