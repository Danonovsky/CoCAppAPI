using System;
using System.Collections.Generic;
using System.Text;
using DbLibrary.Models.Character;

namespace DbLibrary.Models.Characteristic
{
    public class Characteristic
    {
        public Guid Id { get; set; }

        public Guid CharacterId { get; set; }
        public virtual Character.Character Character { get; set; }

        public Guid DefaultCharacteristicId { get; set; }
        public virtual DefaultCharacteristic DefaultCharacteristic { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; } = 0;
    }
}
