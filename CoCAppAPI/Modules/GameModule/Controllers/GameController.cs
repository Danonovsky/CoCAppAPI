using AuthModule.Helpers;
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
    }
}
