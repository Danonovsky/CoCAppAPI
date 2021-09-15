using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Note.Request
{
    public class NoteRequest
    {
        public Guid LocationId { get; set; }
        public string Content { get; set; }
    }
}
