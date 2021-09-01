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

namespace GameModule.Services
{
    public interface IGameService
    {
        public List<Game> GetAll();

        public List<Game> GetUserGames();

        public List<Game> GetPossibleGames();

        public List<Game> GetJoinedGames();
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

        public List<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        public List<Game> GetUserGames()
        {
            User user = _httpContextAccessor.HttpContext.Items["User"] as User;
            return _context.Games.Where(x => x.UserId == user.Id).ToList();
        }

        public List<Game> GetPossibleGames()
        {
            return _context.Games.Where(x => !x.Private).ToList();
        }

        public List<Game> GetJoinedGames()
        {
            return null;
        }


    }
}
