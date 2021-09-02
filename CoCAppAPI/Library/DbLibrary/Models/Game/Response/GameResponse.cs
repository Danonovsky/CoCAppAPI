using DbLibrary.Models.User.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Game
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserListResponse User { get; set; }

        public GameResponse(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            User = new UserListResponse(game.User);
        }
    }
}
