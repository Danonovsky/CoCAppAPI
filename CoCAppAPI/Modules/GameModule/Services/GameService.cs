using DbLibrary.DAL;
using DbLibrary.Models.Game;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using DbLibrary.Models.User;
using AuthModule.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DbLibrary.Models.Game.Request;

namespace GameModule.Services
{
    public interface IGameService
    {
        public List<GameResponse> GetAll();
        public List<GameResponse> GetUserGames();
        public List<GameResponse> GetPossible();
        public List<GameResponse> GetJoinedGames();

        public bool Create(GameCreateRequest model);
    }
    public class GameService : IGameService
    {

        private readonly CoCDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GameService(
            CoCDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<GameResponse> GetAll()
        {
            return _context.Games.Select(x => new GameResponse(x)).ToList();
        }

        public List<GameResponse> GetUserGames()
        {
            User user = _httpContextAccessor.HttpContext.Items["User"] as User;
            return _context.Games.Where(x => x.UserId == user.Id).Select(x => new GameResponse(x)).ToList();
        }

        public List<GameResponse> GetPossible()
        {
            return _context.Games.Where(x => !x.Private).Select(x => new GameResponse(x)).ToList();
        }

        public List<GameResponse> GetJoinedGames()
        {
            return null;
        }

        public bool Create(GameCreateRequest model)
        {
            Game game = new Game()
            {
                Name = model.Name,
                Private = model.Private,
                UserId = (_httpContextAccessor.HttpContext.Items["User"] as User).Id
            };
            _context.Games.Add(game);

            return _context.SaveChanges() > 0;
        }


    }
}
