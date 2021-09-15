using System;
using System.Collections.Generic;
using System.Text;
using DbLibrary.Models.Location;

namespace DbLibrary.Models.Note
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public virtual ICollection<LocationNote> LocationNotes { get; set; }
    }
}
