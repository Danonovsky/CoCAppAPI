using System;
using System.Collections.Generic;
using System.Text;

namespace RollModule.Models
{
    public class RollResponse
    {
        public List<int> Values { get; set; } = new List<int>();
        public int Summary { get; set; }
    }
}
