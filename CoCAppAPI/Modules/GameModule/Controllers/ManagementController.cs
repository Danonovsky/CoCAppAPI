using AuthModule.Helpers;
using DbLibrary.Models.Character.Request;
using DbLibrary.Models.Game.Request;
using DbLibrary.Models.Location.Request;
using DbLibrary.Models.Note.Request;
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
    public class ManagementController : ControllerBase
    {
        private IGameService _gameService;
        private IManagementService _managementService;

        public ManagementController(
            IGameService gameService,
            IManagementService managementService
            )
        {
            _gameService = gameService;
            _managementService = managementService;
        }

        [Authorize]
        [HttpPost("character")]
        public IActionResult AddCharacter(CharacterRequest request)
        {
            if (_managementService.AddCharacter(request)) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpGet("character/all/{id}")]
        public IActionResult GetAllCharacters(Guid id)
        {
            var result = _managementService.GetAllCharacters(id);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("character/{id}")]
        public IActionResult DeleteCharacter(Guid id)
        {
            var result = _managementService.DeleteCharacter(id);
            if (result) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpPost("location")]
        public IActionResult AddLocation(LocationRequest request)
        {
            if (_managementService.AddLocation(request)) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpGet("location/all/{id}")]
        public IActionResult GetAllLocations(Guid id)
        {
            var result = _managementService.GetAllLocations(id);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("location/{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            var result = _managementService.DeleteLocation(id);
            if (result) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpPost("location/note")]
        public IActionResult AddNoteFromLocation(NoteRequest request)
        {
            if (_managementService.AddNoteToLocation(request)) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpGet("location/note/all/{id}")]
        public IActionResult GetNotesFromLocation(Guid id)
        {
            var result =_managementService.GetNotesFromLocation(id);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("location/note/{id}")]
        public IActionResult DeleteNoteFromLocation(Guid id)
        {
            var result = _managementService.DeleteNoteFromLocation(id);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
