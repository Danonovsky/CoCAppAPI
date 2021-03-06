using DbLibrary.Models.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Character
{
    public class Character
    {
        public Guid Id { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Characteristic.Characteristic> Characteristics { get; set; }
        public virtual ICollection<Skill.Skill> Skills { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
