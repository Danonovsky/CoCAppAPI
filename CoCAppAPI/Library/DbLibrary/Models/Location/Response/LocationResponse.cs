using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location.Response
{
    public class LocationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GameId { get; set; }

        public LocationResponse() { }
        public LocationResponse(Location location)
        {
            Id = location.Id;
            Name = location.Name;
            GameId = location.GameId;
        }
    }
}
