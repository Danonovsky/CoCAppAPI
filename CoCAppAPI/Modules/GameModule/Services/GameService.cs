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
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameModule.Services
{
    public interface IGameService
    {
        public GameResponse Get(Guid id);
        public List<GameResponse> GetAll();
        public List<GameResponse> GetUserGames();
        public List<GameResponse> GetPossible();
        public List<GameResponse> GetJoinedGames();

        public bool Create(GameCreateRequest model);
        public bool Join(GamePlayerRequest model);
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

        public GameResponse Get(Guid id)
        {
            var result = _context.Games.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            return new GameResponse(result);
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
            return _context.Games.Include(x => x.User).Where(x => !x.Private).Select(x => new GameResponse(x)).ToList();
        }

        public List<GameResponse> GetJoinedGames()
        {
            User user = _httpContextAccessor.HttpContext.Items["User"] as User;
            var games = _context.GamePlayers.Where(x => x.UserId == user.Id).Select(x => x.GameId).ToList();
            return _context.Games.Include(x => x.User).Where(x => games.Contains(x.Id)).Select(x => new GameResponse(x)).ToList();
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

        public bool Join(GamePlayerRequest model)
        {
            var loggedInId = (_httpContextAccessor.HttpContext.Items["User"] as User).Id;
            Debug.WriteLine("Game GUID: "+model.GameId);
            if (_context.Games.Where(x => x.Id == model.GameId && x.UserId == loggedInId).Any()) return false;
            if (_context.GamePlayers.Where(x => x.UserId == loggedInId).Any()) return false;
            _context.GamePlayers.Add(new GamePlayer()
            {
                UserId = loggedInId,
                GameId = model.GameId
            });
            return _context.SaveChanges() > 0;
        }


    }
}
