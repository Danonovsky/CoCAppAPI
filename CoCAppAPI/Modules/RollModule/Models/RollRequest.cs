using System;
using System.Collections.Generic;
using System.Text;

namespace RollModule.Models
{
    public class RollRequest
    {
        public int Amount { get; set; }
        public int Dice { get; set; }
        public int Static { get; set; }
    }
}
