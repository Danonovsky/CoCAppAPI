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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

        [HttpPost("image"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split(".").Last();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
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

        [Authorize]
        [HttpPost("location/item")]
        public IActionResult AddItemFromLocation(LocationItemRequest request)
        {
            if (_managementService.AddItemToLocation(request)) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpGet("location/item/all/{id}")]
        public IActionResult GetItemsFromLocation(Guid id)
        {
            var result = _managementService.GetItemsFromLocation(id);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("location/item/{id}")]
        public IActionResult DeleteItemFromLocation(Guid id)
        {
            var result = _managementService.DeleteItemFromLocation(id);
            if (result) return Ok();
            else return BadRequest();
        }

        [Authorize]
        [HttpGet("notes/{id}")]
        public IActionResult GetAllNotes(Guid id)
        {
            var result = _managementService.GetAllNotes(id);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("players/{id}")]
        public IActionResult getAllPlayers(Guid id)
        {
            var result = _managementService.GetPlayers(id);
            return Ok(result);
        }

    }
}
