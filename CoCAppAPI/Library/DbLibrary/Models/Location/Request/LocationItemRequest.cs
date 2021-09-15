using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location.Request
{
    public class LocationItemRequest
    {
        public Guid LocationId { get; set; }
        public Guid ItemId { get; set; }
    }
}