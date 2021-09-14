using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Characteristic.Response
{
    public class CharacteristicResponse
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; } = 0;

        public CharacteristicResponse(Characteristic characteristic)
        {
            Id = characteristic.Id;
            CharacterId = characteristic.CharacterId;
            Name = characteristic.DefaultCharacteristic.Name;
            Value = characteristic.Value;
            Advancement = characteristic.Advancement;
        }
    }
}
