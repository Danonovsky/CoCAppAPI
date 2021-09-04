using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Characteristic.Response
{
    public class DefaultCharacteristicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public DefaultCharacteristicResponse(DefaultCharacteristic defaultCharacteristic)
        {
            Id = defaultCharacteristic.Id;
            Name = defaultCharacteristic.Name;
            Value = defaultCharacteristic.Value;
        }
    }
}
