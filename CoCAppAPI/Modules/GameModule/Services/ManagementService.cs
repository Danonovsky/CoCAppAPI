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
                .Where(x => x.GameId == gameId)
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
    }
}
