using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location.Request
{
    public class LocationRequest
    {
        public string Name { get; set; }
        public Guid GameId { get; set; }
    }
}
