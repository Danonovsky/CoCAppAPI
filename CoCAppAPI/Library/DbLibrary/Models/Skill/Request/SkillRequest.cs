using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Skill.Request
{
    public class SkillRequest
    {
        public Guid CharacterId { get; set; }
        public Guid DefaultSkillId { get; set; }
        public int Value { get; set; }
        public int Advancement { get; set; }
    }
}
