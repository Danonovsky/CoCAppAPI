using DbLibrary.Models.Characteristic.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Characteristic
{
    public class DefaultCharacteristic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }

        public DefaultCharacteristic() { }
        public DefaultCharacteristic(DefaultCharacteristicRequest request)
        {
            Name = request.Name;
            Value = request.Value;
        }
    }
}
