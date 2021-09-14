using System;
using System.Collections.Generic;
using System.Text;
using DbLibrary.Models.User;

namespace DbLibrary.Models.Game
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public Guid UserId { get; set; }

        public virtual User.User User { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        public virtual ICollection<Location.Location> Locations { get; set; }
    }
}