using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location
{
    public class LocationItem
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item.Item Item { get; set; }
    }
}
