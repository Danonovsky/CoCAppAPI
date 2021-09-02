using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Game.Request
{
    public class GameCreateRequest
    {
        public string Name { get; set; }
        public bool Private { get; set; }
    }
}
