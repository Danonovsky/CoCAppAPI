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

        [Authorize]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _gameService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("getPossible")]
        public IActionResult GetPossible()
        {
            var games = _gameService.GetPossible();
            return Ok(games);
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult Create(GameCreateRequest model)
        {
            if (_gameService.Create(model)) return Ok();
            else return BadRequest();
        }
    }
}
