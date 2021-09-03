using AuthModule.Helpers;
using DbLibrary.Models.Game.Request;
using GameModule.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(Guid id)
        {
            var game = _gameService.Get(id);
            return Ok(game);
        }

        [Authorize]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _gameService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("possible")]
        public IActionResult GetPossible()
        {
            var games = _gameService.GetPossible();
            return Ok(games);
        }

        [Authorize]
        [HttpGet("joined")]
        public IActionResult GetJoined()
        {
            var games = _gameService.GetJoinedGames();
            return Ok(games);
        }

        [Authorize]
        [HttpGet("userGames")]
        public IActionResult GetUserGames()
        {
            var games = _gameService.GetUserGames();
            return Ok(games);
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult Create(GameCreateRequest model)
        {
            if (_gameService.Create(model)) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpPost("join")]
        public IActionResult Join(GamePlayerRequest model)
        {
            if (_gameService.Join(model)) return Ok();
            else return BadRequest();
        }
    }
}
