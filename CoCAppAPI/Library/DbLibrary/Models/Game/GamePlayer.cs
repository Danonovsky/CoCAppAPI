using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbLibrary.Models.Game
{
    public class GamePlayer
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        public Guid? CharacterId { get; set; }
        public virtual Character.Character Character { get; set; }

        public Guid? UserId { get; set; }
        public virtual User.User User { get; set; }
    }
}
