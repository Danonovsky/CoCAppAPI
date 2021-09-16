using DbLibrary.Models.Location.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid GameId { get; set; }
        public virtual Game.Game Game { get; set; }
        public virtual ICollection<LocationNote> LocationNotes { get; set; }
        public virtual ICollection<LocationItem> LocationItems { get; set; }

        public Location() { }
        public Location(LocationRequest request)
        {
            Name = request.Name;
            GameId = request.GameId;
            Image = request.Image;
        }
    }
}
