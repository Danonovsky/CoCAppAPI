using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location
{
    public class LocationNote
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid NoteId { get; set; }
        public virtual Note.Note Note { get; set; }
    }
}
