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
using DbLibrary.Models.Character.Request;
using DbLibrary.Models.Character;
using DbLibrary.Models.Characteristic;
using DbLibrary.Models.Character.Response;
using DbLibrary.Models.Characteristic.Response;
using DbLibrary.Models.Location.Request;
using DbLibrary.Models.Location;
using DbLibrary.Models.Location.Response;
using DbLibrary.Models.Note.Request;
using DbLibrary.Models.Note;
using DbLibrary.Models.Note.Response;
using DbLibrary.Models.Item.Response;
using DbLibrary.Models.Game.Response;

namespace GameModule.Services
{
    public interface IManagementService
    {

        public bool AddCharacter(CharacterRequest request);
        public List<CharacterResponse> GetAllCharacters(Guid gameId);
        public bool DeleteCharacter(Guid id);
        public bool AddLocation(LocationRequest request);
        public List<LocationResponse> GetAllLocations(Guid id);
        public bool DeleteLocation(Guid id);
        public bool AddNoteToLocation(NoteRequest request);
        public List<NoteResponse> GetNotesFromLocation(Guid locationId);
        public bool DeleteNoteFromLocation(Guid id);
        public bool AddItemToLocation(LocationItemRequest request);
        public List<LocationItemResponse> GetItemsFromLocation(Guid locationId);
        public bool DeleteItemFromLocation(Guid id);
        public List<NoteListResponse> GetAllNotes(Guid id);
        public List<PlayerResponse> GetPlayers(Guid id);
    }
    public class ManagementService : IManagementService
    {
        private readonly CoCDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ManagementService(
            CoCDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool AddCharacter(CharacterRequest request)
        {
            Character insert = new Character
            {
                FirstName = request.FirstName,
                Gender = request.Gender == "Male" ? Gender.Male : Gender.Female,
                LastName = request.LastName
            };

            _context.Add(insert);
            _context.SaveChanges();

            Guid id = insert.Id;

            foreach (var item in request.Characteristics)
            {
                _context.Characteristics.Add(new Characteristic
                {
                    Advancement = item.Advancement,
                    CharacterId = id,
                    DefaultCharacteristicId = item.DefaultCharacteristicId,
                    Value = item.Value
                });
            }

            _context.GamePlayers.Add(new GamePlayer
            {
                CharacterId = id,
                GameId = request.GameId
            });

            return _context.SaveChanges() > 0;
        }

        public List<CharacterResponse> GetAllCharacters(Guid gameId)
        {
            return _context.GamePlayers
                .Where(x => x.GameId == gameId && x.CharacterId != null)
                .Include(x => x.Character)
                .ThenInclude(x => x.Characteristics)
                .ThenInclude(x => x.DefaultCharacteristic)
                .Select(x => new CharacterResponse
                {
                    FirstName = x.Character.FirstName,
                    LastName = x.Character.LastName,
                    Gender = x.Character.Gender.ToString(),
                    Id = x.Character.Id,
                    Characteristics = x.Character.Characteristics.Select(y => new CharacteristicResponse(y)).ToList()
                }).ToList();
        }

        public bool DeleteCharacter(Guid id)
        {
            var gamePlayer = _context.GamePlayers.FirstOrDefault(x => x.CharacterId == id && x.User != null);
            //clear gamePlayers
            if(gamePlayer != default(GamePlayer))
            {
                gamePlayer.CharacterId = null;
            }
            else
            {
                _context.GamePlayers.Remove(_context.GamePlayers.First(x => x.CharacterId == id));
            }

            //clear characteristics
            _context.Characteristics.RemoveRange(
                _context.Characteristics.Where(x => x.CharacterId == id).ToList());

            //clear characters
            _context.Characters.Remove(
                _context.Characters.Find(id));

            return _context.SaveChanges() > 0;
        }

        public bool AddLocation(LocationRequest request)
        {
            _context.Add(new Location(request));
            return _context.SaveChanges() > 0;
        }

        public List<LocationResponse> GetAllLocations(Guid id)
        {
            return _context.Locations.Where(x => x.GameId == id).Select(x => new LocationResponse(x)).ToList();
        }

        public bool DeleteLocation(Guid id)
        {
            _context.Locations.Remove(_context.Locations.Find(id));
            return _context.SaveChanges() > 0;
        }

        public bool AddNoteToLocation(NoteRequest request)
        {
            var note = new Note{ Content = request.Content };
            _context.Notes.Add(note);
            _context.SaveChanges();

            var insert = note.Id;
            _context.LocationNotes.Add(new LocationNote
            {
                LocationId = request.LocationId,
                NoteId = insert
            });
            return _context.SaveChanges() > 0;
        }

        public List<NoteResponse> GetNotesFromLocation(Guid locationId)
        {
            var list = _context.LocationNotes.Where(x => x.LocationId == locationId)
                .Include(x => x.Note)
                .Select(x => new NoteResponse
                {
                    Content = x.Note.Content,
                    Id = x.Note.Id
                }).ToList();
            return list;
        }

        public bool DeleteNoteFromLocation(Guid id)
        {
            _context.LocationNotes.RemoveRange(
                _context.LocationNotes.Where(x => x.NoteId == id).ToList());
            _context.Notes.Remove(_context.Notes.Find(id));
            return _context.SaveChanges() > 0;
        }

        public bool AddItemToLocation(LocationItemRequest request)
        {
            _context.LocationItems.Add(new LocationItem
            {
                ItemId = request.ItemId,
                LocationId = request.LocationId
            });

            return _context.SaveChanges() > 0;
        }

        public List<LocationItemResponse> GetItemsFromLocation(Guid locationId)
        {
            var list = _context.LocationItems.Where(x => x.LocationId == locationId)
                .Include(x => x.Item)
                .ThenInclude(x => x.ItemType)
                .Include(x => x.Item)
                .ThenInclude(x => x.ItemAttributeValues)
                .ThenInclude(x => x.ItemTypeAttribute)
                .Select(x => new LocationItemResponse(x))
                .ToList();
            return list;
        }

        public bool DeleteItemFromLocation(Guid id)
        {
            _context.LocationItems.Remove(
                _context.LocationItems.Where(x => x.Id == id).First());
            return _context.SaveChanges() > 0;
        }

        public List<NoteListResponse> GetAllNotes(Guid id)
        {
            var list = _context.LocationNotes
                .Include(x => x.Location)
                .Include(x => x.Note)
                .Where(x => x.Location.GameId == id)
                .Select(x => new NoteListResponse
                {
                    Location = x.Location.Name,
                    Content = x.Note.Content,
                    Id = x.Note.Id
                }).ToList();
            return list;
        }

        public List<PlayerResponse> GetPlayers(Guid id)
        {
            var list = _context.GamePlayers
                .Where(x => x.GameId == id && x.UserId != null)
                .Include(x => x.User)
                .Select(x => new PlayerResponse
                {
                    Id = x.User.Id,
                    Nickname = x.User.Nickname
                }).ToList();
            return list;
        }
    }
}
