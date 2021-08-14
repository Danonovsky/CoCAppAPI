using DbLibrary.DAL;
using DbLibrary.Models.Game;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace GameModule.Services
{
    public interface IGameService
    {
        public List<Game> GetAll(HttpContext context);
    }
    public class GameService : IGameService
    {

        private readonly CoCDbContext _context;
        public GameService(CoCDbContext context)
        {
            this._context = context;
        }

        public List<Game> GetAll(HttpContext context)
        {
            string token = context.Request?.Headers["Authorization"];//.TryGetValue("Authorization", out (Microsoft.Extensions.Primitives.StringValues)token);
            return null;
        }
    }
}
